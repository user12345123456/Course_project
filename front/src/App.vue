<script setup>
import Order from './components/Order.vue'
import Meal from './components/Meal.vue'
import User from './components/User.vue'
</script>

<template>
  <User></User>
  <Order></Order>
  <Meal></Meal>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
