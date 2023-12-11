<template>
  <div class="meal-container">
    <h2>Meal Information</h2>
    <form @submit.prevent="saveMeal" class="meal-form">
      <label for="name">Name:</label>
      <input type="text" v-model="meal.name" id="name" required>
      <br>
      <label for="price">Price:</label>
      <input type="number" v-model="meal.price" id="price" required>
      <br>
      <label for="description">Description:</label>
      <textarea v-model="meal.description" id="description" required></textarea>
      <br>
      <label for="restaurantId">Restaurant ID:</label>
      <input type="text" v-model="meal.restaurantId" id="restaurantId" required>
      <br>
      <button type="submit">Save</button>
      <button @click.prevent="deleteMeal">Delete</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      meal: {
        name: "",
        price: 0,
        description: "",
        restaurantId: ""
      },
      meals: [] // Добавлена запятая после определения массива
    };
  },
  mounted() {
    this.fetchMeals(); // Получение списка блюд при загрузке компоненты
  },
  methods: {
    fetchMeals() {
      axios.get('https://localhost:7284/Meal')
        .then(response => {
          this.meals = response.data; // Обновление списка блюд
        })
        .catch(error => {
          console.error('Ошибка при получении списка блюд:', error);
          console.error('Статус ошибки:', error.response.status);
          console.error('Текст ошибки:', error.response.data);
        });
    },
    saveMeal() {
      console.log("Saving meal:", this.meal);
      axios.post('https://localhost:7284/Meal', this.meal)
        .then(response => {
          console.log("Meal saved successfully!");
          this.fetchMeals(); // Обновление списка блюд после сохранения
        })
        .catch(error => {
          console.error("Error saving meal:", error);
        });
    },
    deleteMeal() {
  console.log("Deleting meal:", this.meal.id);
  axios.delete(`https://localhost:7284/Meal/${this.meal.id}`)
    .then(response => {
      console.log("Meal deleted successfully!");
      this.fetchMeals(); // Обновление списка блюд после удаления
    })
    .catch(error => {
      console.error("Error deleting meal:", error);
      console.error('Статус ошибки:', error.response.status);
      console.error('Текст ошибки:', error.response.data);
    });
},
    updateMeal() {
      console.log("Updating meal:", this.meal);
      axios.put(`https://localhost:7284/Meal/${this.meal.id}`, this.meal)
        .then(response => {
          console.log("Meal updated successfully!");
          this.fetchMeals(); // Обновление списка блюд после обновления
        })
        .catch(error => {
          console.error("Error updating meal:", error);
        });
    }
  }
};
</script>

<style>
.meal-container {
  max-width: 400px;
  margin: auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #f9f9f9;
}

.meal-container h2 {
  text-align: center;
  margin-bottom: 20px;
}

.meal-form label {
  display: block;
  margin-bottom: 10px;
}

.meal-form input[type="text"],
.meal-form input[type="number"],
.meal-form textarea {
  width: 100%;
  padding: 5px;
  margin-bottom: 10px;
  border: 1px solid #ccc;
  border-radius: 3px;
}

.meal-form button {
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

.meal-form button:hover,
.meal-form button:focus,
.meal-form button:active {
  background-color: #0056b3;
}
</style>