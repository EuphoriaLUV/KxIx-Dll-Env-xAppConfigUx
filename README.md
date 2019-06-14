# xAppConfigUx
Presenter and Interface View for KxIx Environment

## IxAppEnvUx
> Environment Repository Model interface

```c#
    public interface IxAppEnvUx
    {
        xAppEnv Get();
        void Save(xAppEnv env);
    }
```

## xAppEnvUx
> Environment Repository Model
- Stub File Create
- Xml Serialize

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
