using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MEC;
using System;
using Cysharp.Threading.Tasks;

public class Manager_Addressable : Singleton<Manager_Addressable>
{
    //
    public AssetReference SpawnablePrefab;
    Dictionary<EPanelType, GameObject> _dicUI = null;
    Dictionary<string, TextAsset> _dicTable = null;

    //
    public bool pIsInit { private set; get; }
    public bool pIsDoneDownload { private set;get; }
    public long pDownloadedBytes { private set; get; }
    public long pTotalBytes { private set; get; }
    public float pDownloadPercent { private set; get; }


    /// <summary>
    /// 
    /// </summary>
    public async void Init()
    {
        pIsInit = false;

        await DownloadAddressable();
        await LoadAssets_Panel();
        await LoadAssets_Table();

        pIsInit = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task DownloadAddressable()
    {
        //
        //var allKeys = Addressables.ResourceLocators.SelectMany(locator => locator.Keys).Cast<string>();
        //Addressables.ClearDependencyCacheAsync(allKeys);

        await Addressables.InitializeAsync();

        var catalogHandle = Addressables.LoadContentCatalogAsync("https://unityarchive.gcdn.ntruss.com/android/catalog_0.1.bin");
        await catalogHandle.Task;

        if (catalogHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Remote Catalog loaded successfully.");

            // 모든 Key 확인
            Addressables.LoadResourceLocationsAsync("").Completed += handle =>
            {
                foreach (UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation loc in handle.Result)
                {
                    Debug.Log($"Key: {loc.PrimaryKey}, Type: {loc.ResourceType}, InternalId: {loc.InternalId}");
                }
            };
        }
        else
        {
            Debug.LogError("Remote Catalog loaded fail.");
        }

        pIsDoneDownload = false;

        var assetsHandle = Addressables.DownloadDependenciesAsync("Download");
        Timing.RunCoroutine(CoDownload(assetsHandle), Segment.Update);
        await assetsHandle.Task;

        pIsDoneDownload = true;

        if (assetsHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Dependencies downloaded successfully.");
        }
        else
        {
            Debug.LogError("Failed to download dependencies.");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    IEnumerator<float> CoDownload(AsyncOperationHandle handle)
    {
        while (!handle.IsDone)
        {
            var downloadStatus = handle.GetDownloadStatus();
            pDownloadedBytes = downloadStatus.DownloadedBytes;
            pTotalBytes = downloadStatus.TotalBytes;
            pDownloadPercent = downloadStatus.Percent * 100f;
            yield return Timing.WaitForOneFrame;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task LoadAssets_Panel()
    {
        //
        if (_dicUI == null)
            _dicUI = new Dictionary<EPanelType, GameObject>();
        _dicUI.Clear();

        //
        for (EPanelType i = EPanelType.None + 1; i < EPanelType.End; i++)
        {
            //
            if (i == EPanelType.Title || i == EPanelType.Group_0 || i == EPanelType.Group_1 || i == EPanelType.Group_2)
            {
                continue;
            }

            //
            var key = $"Panel_{i}";
            var handle = Addressables.LoadAssetAsync<GameObject>(key);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _dicUI.Add(i, handle.Result);
            }
        }
    }

    public async Task LoadAssets_Table()
    {
        //
        if (_dicTable == null)
            _dicTable = new Dictionary<string, TextAsset>();
        _dicTable.Clear();

        //
        var handle = Addressables.LoadResourceLocationsAsync("Table");
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var item in handle.Result)
            {
                var loadAssetHandle = Addressables.LoadAssetAsync<TextAsset>(item.PrimaryKey);
                await loadAssetHandle.Task;

                if (loadAssetHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    if (_dicTable.ContainsKey(item.PrimaryKey) == false)
                        _dicTable.Add(item.PrimaryKey, loadAssetHandle.Result);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task<T> LoadAssetAsync<T>(object key) where T : class
    {
        try
        {
            var handle = Addressables.LoadAssetAsync<T>(key);
            T result = await handle.Task;

            if (result == null)
                Debug.LogError($"Failed to load asset: {key}");

            return null;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);

            return null;
        }
    }
    
    public GameObject GetUI(EPanelType panelType)
    {
        //
        if (_dicUI.ContainsKey(panelType))
            return _dicUI[panelType];

        //
        return null;
    }


    /// <summary>
    /// 
    /// </summary>
    public void CreatePrefab()
    {
        List<AsyncOperationHandle<GameObject>> handles = new List<AsyncOperationHandle<GameObject>>();

        AsyncOperationHandle<GameObject> handle = SpawnablePrefab.InstantiateAsync();
        handles.Add(handle);
    }

    /// <summary>
    /// 
    /// </summary>
    public void AssetDestruct(GameObject gameObject)
    {
        //
        Addressables.ReleaseInstance(gameObject);
    }

    public TextAsset GetTable(string tableKey)
    {
        //
        if (_dicTable.ContainsKey(tableKey))
            return _dicTable[tableKey];

        //
        return null;
    }
}
