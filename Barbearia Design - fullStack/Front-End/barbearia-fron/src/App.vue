<template>
  <v-app>
    <v-main>
      <Header />
      <router-view />
      <Footer />
    </v-main>
  </v-app>
</template>

<script>
import { defineComponent } from "vue";

// Components

import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";

export default defineComponent({
  name: "App",

  components: {
    Header,
    Footer
  },
});

</script>
<style>
  @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@100&display=swap');
*{
  padding: 0;
  margin: 0;
  font-family: 'Roboto', sans-serif;
}

</style>
