using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using System.Threading.Tasks;
using PetShop.Models;

namespace PetShop.Repository
{
    public class AnimalRepository : IRepository<Animal>
    {
        
        private readonly ShopContext context;

        public AnimalRepository(ShopContext context)
        {
            this.context = context;
        }


        public IEnumerable<Animal> GetAll() => context.Animals;
        public Task<IEnumerable<Animal>> GetAllAsync() => Task.Run(() => (IEnumerable<Animal>)context.Animals.Include(a => a.Comments));


        public Animal GetById(int id) => context.Animals.Where(a => a.Id == id).Include(x => x.Comments).First();
        public Task<Animal> GetByIdAsync(int id) => Task.Run(() => GetById(id));



        public async Task<IEnumerable<Animal>> GetTopTwoAsync()
        {
            var animals = await GetAllAsync();
            return animals.OrderByDescending(x => x.Comments?.Count ?? 0).Take(2);
        }



        public async Task DeleteAsync(Animal entity)
        {

            context.Animals.Remove(entity);
            await context.SaveChangesAsync();

        }


        public async Task AddAsync(Animal entity)
        {
            context.Animals.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(Animal entity)
        {
            var animal = await GetByIdAsync(entity.Id);
            if (animal != null)
            {
                animal.Description = entity.Description;
                await SaveAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }




        //public Task<Animal> GetByIdAsync(int id) => context.Animals.Where(a => a.Id == id).Include(x => x.Comments).FirstAsync();
        /// ////////////
        //public Animal GetById(int id) => GetAll().SingleOrDefault(a => a.Id == id)!;



        //public async Task Add(Animal entity)
        //{
        //    context.Animals.Add(entity);
        //    await Save();
        //}

        //public async Task<Animal?> Get(int id)
        //{
        //    var animals = await GetAll();
        //    return await animals.SingleOrDefaultAsync(a => a.Id == id);
        //}

        //public async Task Delete(int id)
        //{
        //    Animal? a = await Get(id);
        //    if (a == null) return;

        //    context.Animals.Remove(a);
        //    await Save();
        //}

        //public async Task Edit(Animal entity)
        //{
        //    var animal = await Get(entity.Id);
        //    if (animal == null) return;

        //    animal.Name = entity.Name;
        //    animal.CategoryId = entity.CategoryId;
        //    animal.Description = entity.Description;
        //    animal.ImageName = entity.ImageName;
        //    // animal.FileName = entity.FileName;
        //    // todo: change all props

        //    await Save();
        //}




        //public Task<IQueryable<Animal>> GetAll()
        //{
        //    return Task.FromResult<IQueryable<Animal>>(context.Animals.Include(a => a.Comments));
        // }





    }



}
