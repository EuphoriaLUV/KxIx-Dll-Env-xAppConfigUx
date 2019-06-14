using System;
using xAppConfigMx;

namespace xAppConfigUx.Model
{
    public interface IxAppEnvUx
    {
        xAppEnv Get();
        void Save(xAppEnv env);
    }
}
