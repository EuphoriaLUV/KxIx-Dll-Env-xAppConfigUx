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
