using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.Create;

namespace Data.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public CustomerRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer> GetCustomerByIdAsync(Guid id)
    {
        return await _dbContext.Customers.FindAsync(id);
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _dbContext.Customers.Include(ex => ex.Orders).ToListAsync();
    }

    public async Task<Customer> AddCustomerAsync(Customer customer)    
    {
        
        //check if email is already in use
        var existingCustomer = await GetCustomerByEmailAsync(customer.Email);
        if (existingCustomer != null)
        {
            throw new Exception("Email already in use.");
        }
        
        //hash password

        customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
        
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        
        return customer;
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        if (customer != null)
        {
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    public async Task<Customer> GetCustomerByEmailAsync(string email)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }
    
    
}