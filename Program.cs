
List<ProductType> productTypes = new()
{
    new ProductType()
    {
        Id = 1,
        Name = "Apparel"
    },
    new ProductType()
    {
        Id = 2,
        Name = "Potions"
    },
    new ProductType()
    {
        Id = 3,
        Name = "Enchanted Objects"
    },
    new ProductType()
    {
        Id = 4,
        Name = "Wands"
    }
};

List<Product> products = new()
{
    new Product()
    {
        Id = 1,
        Name = "Wand of Redemption",
        Price = 75.00m,
        InStock = true,
        PublicTypeId = 4
    },
    new Product()
    {
        Id = 2,
        Name = "Cloak of Featherfall",
        Price = 150.00m,
        InStock = true,
        PublicTypeId = 1
    },
    new Product()
    {
        Id = 3,
        Name = "Skull of the Forgotten",
        Price = 500.00m,
        InStock = true,
        PublicTypeId = 3
    },
    new Product()
    {
        Id = 4,
        Name = "Ring of Invisibility",
        Price = 100.00m,
        InStock = true,
        PublicTypeId =1
    },
    new Product()
    {
        Id = 5,
        Name = "Potion of Revivify",
        Price = 300.00m,
        InStock = false,
        PublicTypeId = 2
    },
    new Product()
    {
        Id = 6,
        Name = "Potion of Fire Breath",
        Price = 220.00m,
        InStock = true,
        PublicTypeId = 2
    },
    new Product()
    {
        Id = 7,
        Name = "Wand of Illumination",
        Price = 110.00m,
        InStock = true,
        PublicTypeId = 4
    },
    new Product()
    {
        Id = 8,
        Name = "Helm of the Redeemer",
        Price = 500.00m,
        InStock = false,
        PublicTypeId = 1
    },
    new Product()
    {
        Id = 9,
        Name = "Tenacious Defender",
        Price = 65.00m,
        InStock = true,
        PublicTypeId = 1
    }

};

void ListProducts()
{
    decimal totalValue = 0.0m;
    foreach (Product product in products)
    {
        if (product.InStock)
        {
            totalValue += product.Price;
        }
    }

    Console.WriteLine("\t\t Products:\n");

    foreach (Product product in products)
    {
        Console.WriteLine($"{product.Id}. {product.Name}, Price: ${product.Price}, In Stock: {product.InStock}, Type ID: {product.PublicTypeId} \n");
    }
    Console.WriteLine($"\n\t~Total Inventory Value: ${totalValue}~\n");
    Console.Write("Press Enter to continue...");
    Console.ReadLine();
}

void AddProduct()
{
    Console.Write("\n\tEnter the name of the product: ");
    string name = Console.ReadLine();

    Console.Write("\n\tEnter the product's price: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());

    Console.Write("\n\tIs the product in stock? (true/false)");
    bool inStock = Convert.ToBoolean(Console.ReadLine().ToLower().Trim());

    Console.WriteLine("\n\tProduct Types\n");
    foreach (var productType in productTypes)
    {
        Console.WriteLine($"\n\t{productType.Id}. {productType.Name}");
    }

    Console.Write("\n\tEnter product type number\n");
    int productTypeId = Convert.ToInt32(Console.ReadLine());

    Product newProduct = new()
    {
        Id = products.Count + 1,
        Name = name,
        Price = price,
        InStock = inStock,
        PublicTypeId = productTypeId
    };

    products.Add(newProduct);
    Console.WriteLine("\n\tProduct Addition Successful!\n");
}

void UpdateProduct()
{
    foreach (Product product in products)
    {
        Console.WriteLine($"\n\t{product.Id}. {product.Name}");
    }
    Console.Write("\n\tEnter ID # of the product you wish to update: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    Product productBeingUpdated = products.Find(p => p.Id == productId);

    if (productBeingUpdated != null)
    {
        Console.Write("\n\tEnter a new product name, or press Enter to keep current name: ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            productBeingUpdated.Name = newName;
        }

        Console.Write("\n\tEnter new price for product, or press Enter to keep current price: ");
        string newPrice = Console.ReadLine();
        if (!string.IsNullOrEmpty(newPrice))
        {
            productBeingUpdated.Price = Convert.ToDecimal(newPrice);
        }

        Console.Write("\n\tIs the product still availaible? (true/false): ");
        string newAvailability = Console.ReadLine();
        if (!string.IsNullOrEmpty(newAvailability))
        {
            productBeingUpdated.InStock = Convert.ToBoolean(newAvailability.ToLower().Trim());
        }

        foreach (ProductType productType in productTypes)
        {
            Console.WriteLine($"\n\t{productType.Id}. {productType.Name}");
        }
        Console.Write("\n\tChoose a product type ID#: ");
        int newId = Convert.ToInt32(Console.ReadLine());
        if (newId != null)
        {
            productBeingUpdated.PublicTypeId = newId;
        }

        Console.WriteLine("\n\tProduct update successful!\n");

    }
    else
    {
        Console.WriteLine("\n\tProduct not found!\n");
    }
}

void DeleteProduct()
{
    foreach (Product product in products)
    {
        Console.WriteLine($"\n\t{product.Id}. {product.Name}");
    }

    Console.Write("\n\tEnter ID # of the product you wish to delete: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    Product productBeingDeleted = products.Find(p => p.Id == productId);
    if (productBeingDeleted != null)
    {
        products.Remove(productBeingDeleted);
        Console.WriteLine("\n\tProduct deletion successful!\n");
    }
    else
    {
        Console.WriteLine("\n\tProduct not found!\n");
    }
}

string GetProductTypeName(int publicTypeId, List<ProductType> productTypes)
{
    ProductType productType = productTypes.Find(pt => pt.Id == publicTypeId);
    return productType != null ? productType.Name : "Unknown";
}

void ViewByType()
{
    Console.WriteLine("\n\t\t~View Products by Type~\n");
    Console.WriteLine("\tProduct Types:\n");

    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"\t{productType.Id}. {productType.Name}\n");
    }

    Console.Write("\n\tEnter product type ID# to view products: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    var filteredProducts = products.Where(p => p.PublicTypeId == productId);

    if (filteredProducts.Any())
    {
        Console.WriteLine($"\n\t\t~~ {GetProductTypeName(productId, productTypes)} Products ~~\n");

        foreach (Product product in filteredProducts)
        {
            Console.WriteLine($"\tID: {product.Id}, Name: {product.Name}, Price: ${product.Price}, In Stock: {product.InStock}\n");
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("\n\tNo products found for selected product type.");
    }
}

string greeting = "\t\t~~~ R & A Magical Supplies Inventory~~~\n\n";
string choice = null;


Console.WriteLine(greeting);

while (choice != "0")
{
    Console.WriteLine(@"                   Choose An Option:

    0. Exit

    1. View All Products

    2. Add A Product

    3. Update A Product

    4. Delete A Product

    5. View Products by Type
");
    Console.Write("\t\t Enter Your Selection: ");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            Environment.Exit(0);
            break;

        case "1":
            ListProducts();
            break;

        case "2":
            AddProduct();
            break;

        case "3":
            UpdateProduct();
            break;

        case "4":
            DeleteProduct();
            break;

        case "5":
            ViewByType();
            break;


    }

}