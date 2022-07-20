namespace RapidPay.InterfaceAdapters.Presenters
{
    public interface IPresenter<T>
    {
        public T Content { get; }
    }
}