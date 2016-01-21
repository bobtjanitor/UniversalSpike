using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace DomainPCL
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<GameBoardModel>();
        }

        public GameBoardModel GameBoardModel
        {
            get { return ServiceLocator.Current.GetInstance<GameBoardModel>();}
        }
    }
}
