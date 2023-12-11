<template>
  <div class="order-container">
    <h2>Order Information</h2>
    <form @submit.prevent="saveOrder" class="order-form">
     
      <label for="restaurantId">Restaurant ID:</label>
      <input type="text" v-model="order.restaurantId" id="restaurantId" required>
      <br>
      <label for="datetime">Datetime:</label>
      <input type="datetime-local" v-model="order.datetime" id="datetime" required>
      <br>
      <label for="status">Status:</label>
      <select v-model="order.status" id="status" required>
        <option value="pending">Pending</option>
        <option value="in-progress">In Progress</option>
        <option value="completed">Completed</option>
        <option value="cancelled">Cancelled</option>
      </select>
      <br>
      <button type="submit">Save</button>
      <button @click.prevent="deleteOrder">Delete</button>
    </form>
     <!-- Список всех заказов -->
     <ul>
        <li v-for="order in orders" :key="order.id">
          <h3>{{ order.restaurantId }}</h3>
          <p>{{ order.datetime }}</p>
          <p>{{ order.status }}</p>
          <button @click="updateOrder(order)">Update</button>
          <button @click="deleteOrder(order)">Delete</button>
        </li>
      </ul>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      order: {
        restaurantId: "",
        datetime: "",
        status: "pending"
      },
      orders: [] // Добавленное свойство для хранения списка заказов
    };
  },
  mounted() {
    this.fetchOrders(); // Получение списка заказов при загрузке компоненты
  },
  methods: {
    fetchOrders() {
      axios.get('https://localhost:7284/Order')
        .then(response => {
          this.orders = response.data; // Обновление списка заказов
        })
        .catch(error => {
          console.error('Ошибка при получении списка заказов:', error);
          console.error('Статус ошибки:', error.response.status);
          console.error('Текст ошибки:', error.response.data);
        });
    },
    saveOrder() {
      console.log("Saving order:", this.order);
      axios.post('https://localhost:7284/Order', this.order)
        .then(response => {
          console.log("Order saved successfully!");
          this.fetchOrders(); // Обновление списка заказов после сохранения
        })
        .catch(error => {
          console.error("Error saving order:", error);
        });
    },
    deleteOrder(order) {
      console.log("Deleting order:", order.id);
      axios.delete(`https://localhost:7284/Order/${order.id}`)
        .then(response => {
          console.log("Order deleted successfully!");
          this.fetchOrders(); // Обновление списка заказов после удаления
        })
        .catch(error => {
          console.error("Error deleting order:", error);
        });
    },
    updateOrder(order) {
      console.log("Updating order:", order);
      axios.put(`https://localhost:7284/Order/${order.id}`, order)
        .then(response => {
          console.log("Order updated successfully!");
          this.fetchOrders(); // Обновление списка заказов после обновления
        })
        .catch(error => {
          console.error("Error updating order:", error);
        });
    }
  }
};
</script>

<style>
.order-container {
  max-width: 400px;
  margin: auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #f9f9f9;
}

.order-container h2 {
  text-align: center;
  margin-bottom: 20px;
}

.order-form label {
  display: block;
  margin-bottom: 10px;
}

.order-form input[type="text"],
.order-form input[type="datetime-local"],
.order-form select {
  width: 100%;
  padding: 5px;
  margin-bottom: 10px;
  border: 1px solid #ccc;
  border-radius: 3px;
}

.order-form button {
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

.order-form button:hover,
.order-form button:focus,
.order-form button:active {
  background-color: #0056b3;
}
</style>