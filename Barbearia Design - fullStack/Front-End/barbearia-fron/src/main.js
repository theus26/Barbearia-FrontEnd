import { createApp } from "vue";

import App from "./App.vue";
import router from "./router";
import vuetify from "./plugins/vuetify";
import { loadFonts } from "./plugins/webfontloader";
import "./assets/tailwind.css";
import VueTheMask from 'vue-the-mask'


loadFonts();

createApp(App).use(router).use(vuetify).use(VueTheMask).mount("#app");
