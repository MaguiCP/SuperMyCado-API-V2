# SuperMyCado-API-V2

## Português

### Descrição

O **SuperMyCado API V2** é um sistema integrado de gestão para uma cadeia de lojas, composto por duas aplicações que funcionam em conjunto:

1. **Aplicação Node.js com Express e MongoDB**: Gere clientes e encomendas.
2. **Aplicação ASP.NET Core com Entity Framework e SQL Server**: Gere funcionários, lojas, produtos e gamas de produtos.

O sistema facilita a administração eficiente dos dados dos clientes, das encomendas, dos funcionários, das lojas e dos produtos, proporcionando uma solução coesa para otimizar a operação das lojas.

### Funcionalidades

#### Aplicação Node.js

- **Clientes**:
  - **Adicionar Cliente**: Permite a inserção de novos clientes no sistema.
  - **Consultar Clientes**: Disponibiliza a visualização das informações dos clientes registados.
  - **Atualizar Cliente**: Permite modificar as informações de clientes existentes.
  - **Excluir Cliente**: Remove clientes do sistema.

- **Encomendas**:
  - **Adicionar Encomenda**: Regista novas encomendas feitas pelos clientes.
  - **Consultar Encomendas**: Permite a visualização das encomendas existentes.
  - **Atualizar Encomenda**: Modifica o estado e detalhes das encomendas.
  - **Excluir Encomenda**: Remove encomendas do sistema.

#### Aplicação ASP.NET Core

- **Funcionários**:
  - **Adicionar Funcionário**: Permite a inserção de novos funcionários no sistema.
  - **Consultar Funcionários**: Disponibiliza a visualização das informações dos funcionários registados.
  - **Atualizar Funcionário**: Permite modificar as informações de funcionários existentes.
  - **Excluir Funcionário**: Remove funcionários do sistema.

- **Lojas**:
  - **Adicionar Loja**: Regista novas lojas no sistema.
  - **Consultar Lojas**: Permite a visualização das informações das lojas existentes.
  - **Atualizar Loja**: Modifica os detalhes das lojas.
  - **Excluir Loja**: Remove lojas do sistema.

- **Produtos**:
  - **Adicionar Produto**: Permite a inserção de novos produtos no sistema.
  - **Consultar Produtos**: Disponibiliza a visualização das informações dos produtos.
  - **Atualizar Produto**: Modifica os detalhes dos produtos existentes.
  - **Excluir Produto**: Remove produtos do sistema.

- **Gamas de Produtos**:
  - **Adicionar Gama de Produtos**: Regista novas gamas de produtos.
  - **Consultar Gamas**: Permite a visualização das informações das gamas de produtos.
  - **Atualizar Gama de Produtos**: Modifica os detalhes das gamas de produtos.
  - **Excluir Gama de Produtos**: Remove gamas de produtos do sistema.

### Melhorias

A versão atual do **SuperMyCado API V2** inclui as seguintes melhorias:

#### Aplicação Node.js

- **Validação de Dados**:
  - Implementa validações básicas para garantir a integridade dos dados dos clientes e das encomendas, assegurando que as informações inseridas estejam corretas e completas.

#### Aplicação ASP.NET Core

- **Estrutura de Dados**:
  - **Funcionários**: Gere informações detalhadas dos funcionários, incluindo associações com lojas.
  - **Lojas**: Facilita a criação e gestão das lojas, incluindo informações sobre localização e dados relevantes.
  - **Produtos**: Inclui gestão detalhada dos produtos, as suas gamas e lojas associadas.
  - **Gamas de Produtos**: Gere as diferentes gamas de produtos disponíveis, permitindo a organização e categorização dos produtos de forma eficiente.

- **Consistência de Dados**:
  - Assegura que as operações realizadas no sistema, como a adição, atualização e exclusão de funcionários, lojas, produtos e gamas de produtos, sejam executadas de forma coesa e consistente.

## English

### Description

**SuperMyCado API V2** is an integrated management system for a chain of stores, consisting of two applications that work together:

1. **Node.js Application with Express and MongoDB**: Manages clients and orders.
2. **ASP.NET Core Application with Entity Framework and SQL Server**: Manages employees, stores, products, and product ranges.

The system facilitates efficient management of client data, orders, employees, stores, and products, providing a cohesive solution to optimize store operations.

### Features

#### Node.js Application

- **Clients**:
  - **Add Client**: Allows the insertion of new clients into the system.
  - **View Clients**: Provides access to view information about registered clients.
  - **Update Client**: Allows modification of existing client information.
  - **Delete Client**: Removes clients from the system.

- **Orders**:
  - **Add Order**: Registers new orders placed by clients.
  - **View Orders**: Allows viewing of existing orders.
  - **Update Order**: Modifies the status and details of orders.
  - **Delete Order**: Removes orders from the system.

#### ASP.NET Core Application

- **Employees**:
  - **Add Employee**: Allows the insertion of new employees into the system.
  - **View Employees**: Provides access to view information about registered employees.
  - **Update Employee**: Allows modification of existing employee information.
  - **Delete Employee**: Removes employees from the system.

- **Stores**:
  - **Add Store**: Registers new stores in the system.
  - **View Stores**: Allows viewing of existing store information.
  - **Update Store**: Modifies details of stores.
  - **Delete Store**: Removes stores from the system.

- **Products**:
  - **Add Product**: Allows the insertion of new products into the system.
  - **View Products**: Provides access to view information about products.
  - **Update Product**: Modifies details of existing products.
  - **Delete Product**: Removes products from the system.

- **Product Ranges**:
  - **Add Product Range**: Registers new product ranges.
  - **View Ranges**: Allows viewing of information about product ranges.
  - **Update Product Range**: Modifies details of product ranges.
  - **Delete Product Range**: Removes product ranges from the system.

### Improvements

The current version of **SuperMyCado API** includes the following improvements:

#### Node.js Application

- **Data Validation**:
  - Implements basic validations to ensure the integrity of client and order data, ensuring that the entered information is accurate and complete.

#### ASP.NET Core Application

- **Data Structure**:
  - **Employees**: Manages detailed employee information, including store associations.
  - **Stores**: Facilitates store creation and management, including location and relevant data.
  - **Products**: Includes detailed management of products, their ranges, and associated stores.
  - **Product Ranges**: Manages the different product ranges available, allowing for efficient organization and categorization of products.

- **Data Consistency**:
  - Ensures that operations performed on the system, such as adding, updating, and deleting employees, stores, products, and product ranges, are carried out in a coherent and consistent manner.
