namespace InterfaceAdapters.RapidPay.Presenters
{
    public interface IPresenter<T>
    {
        public T Content { get; }
    }
}