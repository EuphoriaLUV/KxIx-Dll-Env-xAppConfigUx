using System;
using xAppConfigMx;
using xAppConfigUx.Model;
using xAppConfigUx.View;

namespace xAppConfigUx.Presenter
{
    public class xAppEnvUxPresenter
    {
        private readonly IxAppEnvUxView     _view;
        private readonly IxAppEnvUx         _repo;

        public xAppEnvUxPresenter(IxAppEnvUxView view, IxAppEnvUx repository)
        {
            _view = view;
            view.Presenter = this;
            _repo = repository;

            UpdateAppEnvView();
        }

        public void UpdateAppEnvView()
        {
            var env = _repo.Get();

            _view.DatabaseType      = env.DatabaseType;
            _view.UseDBItemChk      = env.UseDBItemChk;
            _view.UseWebItemTitle   = env.UseWebItemTitle;
            _view.Review            = env.Review;
            _view.Purchases         = env.Purchases;
        }

        public void ApplyEnv()
        {
            xAppEnv env = _repo.Get();
            env.UseDBItemChk        = _view.UseDBItemChk;
            env.UseWebItemTitle     = _view.UseWebItemTitle;
            env.Review              = _view.Review;
            env.Purchases           = _view.Purchases;

            UpdateAppEnvView();
        }

        public void SaveEnv()
        {
//             AppEnv env = _repo.GetEnv();
//             env.HistoryPath         = _view.HistoryPath;
//             env.UseDBItemChk        = _view.UseDBItemChk;
//             env.UseWebItemTitle     = _view.UseWebItemTitle;

            _repo.Save(_repo.Get());

            UpdateAppEnvView();
        }
    }
}
