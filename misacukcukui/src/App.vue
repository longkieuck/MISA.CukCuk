<template>
  <div id="app">
    <TheNavbar/>
    <TheHeader/>
    <TheContent/>
  </div>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue'
import TheContent from './components/layout/TheContent.vue'
import TheNavbar from './components/layout/TheNavbar.vue'
export default {
  name: 'App',
  components: {
    TheHeader,
    TheContent,
    TheNavbar
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
input:focus{
  border: 1px solid #2CA01C;
}
input::placeholder {
    font-style: italic;
    color: #c4c4c4;
}
</style>
