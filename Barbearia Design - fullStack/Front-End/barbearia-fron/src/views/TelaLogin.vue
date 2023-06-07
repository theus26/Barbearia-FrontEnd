<template>
  <main>
    <div class="container-general">
      <!-- Primeira Seção -->

      <section class="section">
        <div class="container-img">
          <v-img src="../assets/images.jpg" alt="Logo Section" width="450" height="390"> </v-img>
        </div>
      </section>

      <!-- Segunda Seção -->

      <section class="section">
        <div class="container-title">
          <h1 class="txt-login">Faça o Login</h1>
        </div>
        <div class="container-form">

          <v-form v-model="form" @submit.prevent="onSubmit">
            <v-text-field v-model="Email" :readonly="loading" :rules="[required, Emails]" outilined class="mb-2"
              label="Digite seu Email:" placeholder="example@gmail.com"></v-text-field>
            <v-text-field :append-icon="show4 ? 'mdi-eye' : 'mdi-eye-off'" :type="show4 ? 'text' : 'password'"
              @click:append="show4 = !show4" v-model="Password" :readonly="loading"
              :rules="[required, rules.min, rules.letraNum]" label="Senha" placeholder="Insira sua senha."></v-text-field>
            <br>
            <v-btn :disabled="!form" :loading="loading" block color="success" size="large" type="submit"
              variant="elevated">
              Entrar
            </v-btn>
            <div class="container-link">
              <router-link title="Clique aqui!" to="TelaCadastro">Deseja Criar uma Conta?</router-link>
            </div>
          </v-form>

        </div>

      </section>


    </div>
  </main>
</template>
<script>

import { Login } from "../Services/Api"
import { GetSession } from "../Services/Api"

export default {
  data: () => ({
    show4: false,
    form: false,
    Email: null,
    Password: null,
    loading: false,
    rules: {
      required: (value) => !!value || "Preencha o campo ",
      letraNum: (v) =>
        /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/.test(v) ||
        "Senha deve conter letra e número.",
      min: (v) => v.length >= 8 || "Min 8 caracteres",
    },
  }),

  methods: {
    async onSubmit() {
      if (!this.form) return
      this.loading = true
      const result = await Login(this.Email, this.Password)
      if (result.status === 200) {
        const token = result.data.token
        const IdUser = result.data.idUser
        const Name = result.data.userName
        const Barber = result.data.isBarber
        const Admin = result.data.isAdmin
        localStorage.setItem("Token", token), localStorage.setItem("IdUser", IdUser), localStorage.setItem("Name", Name), localStorage.setItem("Admin", Admin), localStorage.setItem("Barber", Barber)
        setTimeout(() => (this.loading = false, this.$router.push('/TelaPrincipal')), 1500)
      }
      else {
        if (result.code === 400) {
          this.$swal("Error", "Email OU Senha Incorretos", "error");
          this.loading = false
        }
      }

    },
    required(v) {
      return !!v || 'Campos não pode ser vazio, Preencha os campos.'
    },
    Emails(v) {
      if (/^[_a-z0-9-.]+@[a-z.-]+\.[a-z]+$/i.test(v)) return true
      return 'Deve ser um e-mail valido.'
    },
    async GetSession() {
      const result = await GetSession()
      if (result === 200) {

        this.$router.push('/TelaPrincipal')

      } else {
        console.log("Session Invalid");
        this.$router.push('/')
      }
    }
  },

  mounted() {
    this.GetSession();
  }
}
</script>


<style scoped>
.container-general {
  margin-top: 15px;
  width: 100%;
  height: 100%;
  display: flex;
}

.section {
  width: 50%;
  height: 100%;
  margin-top: 2.5rem;
}

.container-title {
  text-align: center;
  font-size: xx-large;
  font-weight: 800;
  margin-top: 4rem;
  margin-bottom: 3rem;
}

.container-form {
  margin-bottom: 25px;
  margin: 0 auto;
  margin-right: 2rem;
}

.container-img {
  display: flex;
  justify-content: center;
  align-items: center;
}


.container-link {

  /* superior | direita | inferior | esquerda */
  padding: 25px 0 0 0;
  text-align: end;
  font-size: x-small;
  font-weight: bold;
  color: #0000FF;

}

@media (max-width: 599px) {
  .container-img {
    display: none;
  }

  .container-form {
    width: 20rem;
    height: 100%;
    margin-left: -160px;
    margin-top: -35px;
  }

  .container-title {
    margin: 0 auto;
  }

  h1 {
    margin-left: -150px;
    margin-bottom: 5rem;
  }

  .container-link {
    /* superior | direita | inferior | esquerda */
    padding: 1rem 0 0 0;
    text-align: start;
    font-size: x-small;
    font-weight: bold;
    color: #0000FF;
    margin-bottom: 5rem;
  }


}
</style>