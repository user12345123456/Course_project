<template>
    <div class="user-container">
      <h2>User Information</h2>
      <form @submit.prevent="saveUser" class="user-form">
        
        <label for="name">Name:</label>
        <input type="text" v-model="user.name" id="name" required>
        <br>
        <label for="surname">Surname:</label>
        <input type="text" v-model="user.surname" id="surname" required>
        <br>
        <label for="email">Email:</label>
        <input type="email" v-model="user.email" id="email" required>
        <br>
        <label for="password">Password:</label>
        <input type="password" v-model="user.password" id="password" required>
        <br>
        <label for="address">Address:</label>
        <input type="text" v-model="user.address" id="address" required>
        <br>
        <label for="phoneNumber">Phone Number:</label>
        <input type="tel" v-model="user.phoneNumber" id="phoneNumber" required>
        <br>
        <button type="submit">Save</button>
        <button @click.prevent="deleteUser">Delete</button>
      </form>
      <!-- Список всех пользователей -->
      <ul>
        <li v-for="user in users" :key="user.id">
          <h3>{{ user.name }}</h3>
          <p>{{ user.surname }}</p>
          <p>{{ user.email }}</p>
          <p>{{ user.phoneNumber }}</p>
          <p>{{ user.address }}</p>
          <button @click="updateUser(user)">Update</button>
          <button @click="deleteUser(user)">Delete</button>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        user: {
          
          name: "",
          surname: "",
          email: "",
          password: "",
          address: "",
          phoneNumber: ""
        },
        users: [] // Список пользователей
      };
    },
    mounted() {
      this.fetchUsers(); // Получение списка пользователей при загрузке компоненты
    },
    methods: {
      fetchUsers() {
        // Отправка запроса на сервер для получения списка пользователей
        axios.get('https://localhost:7284/User')
          .then(response => {
            // Обработка успешного получения списка пользователей
            this.users = response.data;
          })
          .catch(error => {
            // Обработка ошибки при получении списка пользователей
            console.error('Ошибка при получении списка пользователей:', error);
            console.error('Статус ошибки:', error.response.status);
            console.error('Текст ошибки:', error.response.data);
          });
      },
      saveUser() {
        // Здесь можно добавить логику для сохранения пользователя на сервере
        console.log("Saving user:", this.user);
        // Вызов метода API для сохранения пользователя на сервере
        axios.post('https://localhost:7284/User', this.user)
          .then(response => {
            console.log("User saved successfully!");
            this.fetchUsers(); // Обновление списка пользователей после сохранения
          })
          .catch(error => {
            console.error("Error saving user:", error);
          });
      },
      deleteUser(user) {
        // Здесь можно добавить логику для удаления пользователя на сервере
        console.log("Deleting user:", user.id);
        // Вызов метода API для удаления пользователя на сервере
        axios.delete(`https://localhost:7284/User/${user.id}`)
          .then(response => {
            console.log("User deleted successfully!");
            this.fetchUsers(); // Обновление списка пользователей после удаления
          })
          .catch(error => {
            console.error("Error deleting user:", error);
          });
      },
      updateUser(user) {
        // Здесь можно добавить логику для обновления пользователя на сервере
        console.log("Updating user:", user);
        // Вызов метода API для обновления пользователя на сервере
        axios.put(`https://localhost:7284/User/${user.id}`, user)
          .then(response => {
            console.log("User updated successfully!");
            this.fetchUsers(); // Обновление списка пользователей после обновления
          })
          .catch(error => {
            consol.error("Error updating user:", error);
          });
      }
    }
  };
  </script>
  
  <style>
  .user-container {
    max-width: 400px;
    margin: auto;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    background-color: #f9f9f9;
  }
  
  .user-container h2 {
    text-align: center;
    margin-bottom: 20px;
  }
  
  .user-form label {
    display: block;
    margin-bottom: 10px;
  }
  
  .user-form input[type="text"],
  .user-form input[type="email"],
  .user-form input[type="password"],
  .user-form input[type="tel"] {
    width: 100%;
    padding: 5px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
  }
  
  .user-form button {
    display: block;
    width: 100%;
    padding: 10px;
    margin-top: 10px;
    border: none;
    border-radius: 3px;
    background-color: #007bff;
    color: #fff;
    cursor: pointer;
  }
  
  .user-form button:hover,
  .user-form button:focus,
  .user-form button:active {
    background-color: #0056b3;
  }
  </style>