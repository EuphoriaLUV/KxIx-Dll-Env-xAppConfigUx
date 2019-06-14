# xAppConfigUx
Presenter and Interface View for KxIx Environment

## MODEL
- IxAppEnvUx
> Environment Repository Model interface

```c#
    public interface IxAppEnvUx
    {
        xAppEnv Get();
        void Save(xAppEnv env);
    }
```

- xAppEnvUx
  - Stub File Create
  - Xml Serialize
> Environment Repository Model

```c#
    public class xAppEnvUx : IxAppEnvUx
    {
        public xAppEnvUx(string fullPath)
        {  
            ...
        }

        public xAppEnv Get();
        public void Save(xAppEnv env);
    }
```

## VIEW
> Environment View interface
```c#
    public interface IxAppEnvUxView
    {
        int UseWebItemTitle { get; set; }
        int UseDBItemChk { get; set; }
        int DatabaseType { get; set; }

        xReviewEnv Review { get; set; }
        xPurchaseEnv Purchases { get; set; }

        Presenter.xAppEnvUxPresenter Presenter { set; }
    }

```
## Presenter
> Environment Presenter
```c#
    public xAppEnvUxPresenter(IxAppEnvUxView view, IxAppEnvUx repository)
    {
        ...
    }

    public void UpdateAppEnvView();
    public void ApplyEnv();
    public void SaveEnv();
```
