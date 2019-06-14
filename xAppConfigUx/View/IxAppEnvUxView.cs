using System;
using xAppConfigMx;

namespace xAppConfigUx.View
{
    public interface IxAppEnvUxView
    {
        int UseWebItemTitle { get; set; }
        int UseDBItemChk { get; set; }
        int DatabaseType { get; set; }

        xReviewEnv Review { get; set; }
        xPurchaseEnv Purchases { get; set; }

        Presenter.xAppEnvUxPresenter Presenter { set; }
    }
}
