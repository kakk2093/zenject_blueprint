using System;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public GamePlayService GamePlayServicePrefab;
    public SceneLoadService SceneLoadServicePrefab;
    public SaveValueService SaveValueService;
    public MoneyService MoneyServicePrefab;
    public SaveLoadService SaveLoadServicePrefab;   

    public override void InstallBindings()
    {
        BindSaveValueService();
        BindGamePlayService();
        BindSceneLoadService();
        BindMoneyService();
        BindSaveLoadService();
    }

    private void BindSaveLoadService()
    {
        Container
           .Bind<ISaveLoadService>()
           .FromComponentInNewPrefab(SaveLoadServicePrefab)
           .UnderTransform(transform)
           .AsSingle()
           .NonLazy();
    }

    private void BindGamePlayService()
    {
        Container
          .Bind<IGamePlayService>()
          .FromComponentInNewPrefab(GamePlayServicePrefab)
          .UnderTransform(transform)
          .AsSingle()
          .NonLazy();
    }
    private void BindSceneLoadService()
    {
        Container
          .Bind<ISceneLoadService>()
          .FromComponentInNewPrefab(SceneLoadServicePrefab)
          .UnderTransform(transform)
          .AsSingle()
          .NonLazy(); 
    }
    private void BindSaveValueService()
    {
        Container
          .Bind<ISaveValueService>()
          .FromComponentInNewPrefab(SaveValueService)
          .UnderTransform(transform)
          .AsSingle()
          .NonLazy(); 
    }
    private void BindMoneyService()
    {
        Container
          .Bind<IMoneyService>()
          .FromComponentInNewPrefab(MoneyServicePrefab)
          .UnderTransform(transform)
          .AsSingle()
          .NonLazy();
    }
}
