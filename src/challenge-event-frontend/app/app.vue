<script setup lang="ts">
useHead({
  title: 'Event Web App'
})
</script>

<template>
  <div class="webapp">
    <header>
      <h1>Event Web App</h1>
    </header>
    <div class="main-content flex-column flex-grow">
      <NuxtPage />
    </div>
  </div>
</template>

<style scoped lang="scss">
@use 'sass:color';

.webapp {
  height: 100vh;
  display: flex;
  flex-direction: column;
}

.main-content{
  padding: 0.2rem 1rem;
}

header {
  background-color: color.adjust(red, $lightness: 40%);
  padding: 5px;
}


</style>