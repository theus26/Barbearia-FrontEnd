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
            <v-text-field v-model="email" :readonly="loading" :rules="[required, Email]" outilined class="mb-2"
              label="Digite seu Email:" placeholder="example@gmail.com"></v-text-field>
            <v-text-field v-model="password" :readonly="loading" :rules="[required, rules.min, rules.letraNum]"
              label="Senha" placeholder="Insira sua senha."></v-text-field>
            <br>
            <v-btn :disabled="!form" :loading="loading" block color="success" size="large" type="submit"
              variant="elevated">
              Entrar
            </v-btn>
            <div class="container-link">
              <router-link title="Clique aqui!" to="TelaCadastro">Deseja Criar Conta?</router-link>
            </div>
          </v-form>

        </div>

      </section>


    </div>
  </main>
</template>

<script>
export default {
  data: () => ({
    form: false,
    email: null,
    password: null,
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
    onSubmit() {
      if (!this.form) return
      this.loading = true
      setTimeout(() => (this.loading = false), 2000)
      const obj = {
        email: this.email,
        senha: this.password
      }
      console.log(obj)
    },
    required(v) {
      return !!v || 'Campos não pode ser vazio, Preencha os campos.'
    },
    Email(v) {
      if (/^[_a-z0-9-]+@[a-z.-]+\.[a-z]+$/i.test(v)) return true
      return 'Deve ser um e-mail valido.'
    },
  },
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
  margin-right: 7rem;
}

.container-img {
  margin-top: 1.5rem;
  margin-left: 7rem;
}
.txt-login{
  margin-left: -8rem;
}

.container-link{
  /* superior | direita | inferior | esquerda */
  padding: 30px 0em 0 47em;
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

  .text-login{
    margin-top: -10px;
  }

  .container-link{
    padding: 30px 0em 10px 0em;
  font-size: x-small;
  font-weight: bold;
  color: #0000FF;
  }
}
</style>