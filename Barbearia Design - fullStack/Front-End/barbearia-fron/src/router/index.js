import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: HomeView,
  },
  {
    path: "/TelaCadastro",
    name: "Tela de Cadastro",

    component: () =>
      import(/* webpackChunkName: "about" */ "../views/TelaCadastro.vue"),
  },
  {
    path: "/TelaPrincipal",
    name: "Tela Principal",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/TelaPrincipal.vue"),
  },

  {
    path: "/TelaAllAgendamentos",
    name: "TelaTodosAgendamentos",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/TelaAllAgendamentos.vue"),
  },

  {
    path: "/TelaMeusAgendamentos",
    name: "TelaMeusAgendamentos",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/TelaMeusAgendamentos.vue"),
  },

  {
    path: "/TelaRealizarAgendamentos",
    name: "TelaRealizarAgendamentos",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/TelaRealizarAgendamentos.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
