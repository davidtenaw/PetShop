using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Repository
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly ShopContext context;
        public CommentRepository(ShopContext context)
        {
            this.context = context;
        }



        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }


        public IEnumerable<Comment> GetAll() => context.Comments;
        public Task<IEnumerable<Comment>> GetAllAsync() => context.Comments.ToListAsync().ContinueWith(task => (IEnumerable<Comment>)task.Result);


        public Comment GetById(int id) => context.Comments.Where(a => a.Id == id).First();
        public Task<Comment> GetByIdAsync(int id) => Task.Run(() => GetById(id));


        public async Task DeleteAsync(Comment entity)
        {

            context.Comments.Remove(entity);
            await context.SaveChangesAsync();

        }


        public async Task AddAsync(Comment entity)
        {
            context.Comments.Add(entity);
            await context.SaveChangesAsync();
        }

        async Task IRepository<Comment>.EditAsync(Comment entity)
        {
            var comment = await GetByIdAsync(entity.Id);
            if (comment != null)
            {
                comment.Description = entity.Description;
                comment.Edit = false;
                SaveAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

       


}
