# ChatBotModelAPI

This is a RESTful API that serves as an integration layer for a **BERT-based Python chatbot**. It allows clients to send user messages and receive AI-generated responses using the **BERT NLP model**.

## Features
- Accepts user messages via HTTP requests
- Communicates with the BERT-based chatbot model
- Returns AI-generated responses
- Implements JWT authentication for secure API access

## Technologies Used
- **.NET Core Web API** (C#)
- **Entity Framework Core** (for database operations)
- **JWT Authentication** (for secure access)
- **Python & BERT NLP Model** (for chatbot responses)
- **PostgreSQL / SQL Server** (for message storage)

## Prerequisites
Ensure you have the following installed:
- .NET 7 or later
- Python 3.8+
- PostgreSQL or SQL Server (if using a database)
- Docker (optional, for containerization)

## Setup Instructions
### 1. Clone the Repository
```sh
git clone https://github.com/yourusername/ChatBotModelAPI.git
cd ChatBotModelAPI
```

### 2. Configure Environment Variables
Create an `.env` file in the project root:
```
JWT_SECRET=your_jwt_secret_key
BERT_API_URL=http://localhost:5001/api/chatbot
DATABASE_CONNECTION_STRING=your_database_connection_string
```

### 3. Install Dependencies
```sh
dotnet restore
```

### 4. Run Database Migrations (if applicable)
```sh
dotnet ef database update
```

### 5. Start the API
```sh
dotnet run
```

The API will be available at `http://localhost:5000`.

## API Endpoints
### 1. **Send a Chat Message**
#### `POST /api/chat/send`
**Description:** Sends a user message to the chatbot and returns a response.

#### **Request Body:**
```json
{
  "content": "Hello, how are you?"
}
```
#### **Response:**
```json
{
  "response": "I'm just a bot, but I'm doing great! How can I help?"
}
```

### 2. **User Authentication**
#### `POST /api/auth/login`
Authenticate and receive a JWT token.

#### **Request Body:**
```json
{
  "username": "user123",
  "password": "securepassword"
}
```
#### **Response:**
```json
{
  "token": "your_jwt_token"
}
```

### 3. **Retrieve Chat History**
#### `GET /api/chat/history`
**Headers:**
```http
Authorization: Bearer your_jwt_token
```
#### **Response:**
```json
[
  { "content": "Hello!", "response": "Hi there!" },
  { "content": "What's your name?", "response": "I'm a chatbot powered by BERT!" }
]
```

## Running with Docker
```sh
docker build -t chatbot-api .
docker run -p 5000:5000 --env-file .env chatbot-api
```

## Contributing
Feel free to open a PR or issue for any improvements!

## License
This project is licensed under the MIT License.

