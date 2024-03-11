namespace BlazorApp4.Services
{
    public interface IService<T>
    {
        public void Delete(string id);

        public T GetById(string id);

        public List<T> GetAll();

        public void SaveOrUpdate(T obj);
    }
}
