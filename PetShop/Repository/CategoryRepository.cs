using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ShopContext context;

        public CategoryRepository(ShopContext context)
        {
            this.context = context;
        }


        public async Task DeleteAsync(Category entity)
        {

            context.Categories.Remove(entity);
            await context.SaveChangesAsync();

        }


        public async Task AddAsync(Category entity)
        {
            context.Categories.Add(entity);
            await context.SaveChangesAsync();
        }

        async Task IRepository<Category>.EditAsync(Category entity)
        {
            var comment = await GetByIdAsync(entity.Id);
            if (comment != null)
            {
                comment.Description = entity.Description;

                SaveAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }


        public async Task<IEnumerable<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }


        public Task<IEnumerable<Category>> GetAllAsync() => Task.Run(() => (IEnumerable<Category>)context.Categories);


        public Category GetById(int id) => context.Categories
    .Where(a => a.Id == id)
    .Include(x => x.Animals) // Replace 'x.Animals' with the actual name of the property holding the animals collection
    .FirstOrDefault();

        public Task<Category> GetByIdAsync(int id) => Task.Run(() => GetById(id));

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}



    
