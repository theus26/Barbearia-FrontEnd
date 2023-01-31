<template>
  <Header />
  <TelaLogin />
  <Footer />
</template>

<script>
import { defineComponent } from "vue";

// Components
import TelaLogin from "../components/TelaLogin.vue";
import Header from "../components/Header.vue";
import Footer from "../components/Footer.vue";

export default defineComponent({
  name: "HomeView",

  components: {
    TelaLogin,
    Header,
    Footer
  },
});
</script>
