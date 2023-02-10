<template>
  <main>
    <div class="components">
      <NavBar />
    </div>
    <br>
    <br>
    <ContainerBox>
      <div class="container-title">
        <h1>Editar Usuário</h1>
      </div>

      <div class="container-form">
        <v-form v-model="form" @submit.prevent="onSubmit">
          <v-container>
            <v-row>
              <v-col cols="12" md="15">
                <v-text-field v-model="Name" maxlength="30" :rules=[required,Nome,MinName] :counter="10"
                  label="Informe seu Nome"></v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12" md="6">
                <v-text-field v-model="Phone" v-mask="['(##) ####-####', '(##) #####-####']" :readonly="loading"
                  :rules="[required, PhoneRules]" label="Informe seu telefone"
                  placeholder="Ex: 7998869-2589"></v-text-field>
              </v-col>

              <v-col cols="12" md="6">
                <v-text-field v-model="CPF" v-mask="'###.###.###-##'" :readonly="loading" :rules="[required, CpfRules]"
                  label="Informe seu CPF" placeholder="Ex: 000.000.000-00"></v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12" md="6">
                <v-text-field v-model="Email" :readonly="loading" :rules="[required, Emails]" label="Informe seu E-mail"
                  placeholder="Ex: joao@gmail.com"></v-text-field>
              </v-col>

              <v-col cols="12" md="6">
                <v-text-field :append-icon="show4 ? 'mdi-eye' : 'mdi-eye-off'" :type="show4 ? 'text' : 'password'"
                  @click:append="show4 = !show4" v-model="Password" :readonly="loading" :rules="[required, Min, letraNum]"
                  :counter="8" label="Informe a sua Senha"></v-text-field>
              </v-col>
            </v-row>
            <br>
            <br>
            <v-btn :disabled="!form" :loading="loading" block color="success" size="large" type="submit"
              variant="elevated">
              Editar Usuario
            </v-btn>
          </v-container>
        </v-form>
      </div>

    </ContainerBox>

  </main>
</template>

<script>
import { UpdateUser } from "@/Services/Api";
import { validate } from "gerador-validador-cpf";
import validator from 'validator';
import ContainerBox from '../components/ContainerBox.vue'
import NavBar from '../components/NavBar.vue'

export default {
  name: 'TelaCadastro',
  components: {
    ContainerBox,
    NavBar
  },
  data: () => ({
    show4: false,
    form: false,
    valid: false,
    Name: null,
    Email: '',
    Password: '',
    CPF: '',
    Phone: '',
    loading: null,
  }),

  methods: {

    async onSubmit() {
      if (!this.form) return
      setTimeout(() => {
        this.loading = true
      }, 2000)
      const IdUser = localStorage.getItem('IdUser');
      const result = await UpdateUser(IdUser, this.Name, this.Email, this.Password, this.CPF, this.Phone);
      if (result.status === 200) {
        this.$swal("Sucesso", "Usuário Editado com sucesso!", "success");
        this.$router.push("/TelaPrincipal")
      }
      else {

        if (result.code === 400) {
          this.loading = false
          this.$swal("Error", "Não foi Possivel realizar agendamento", "error");
        }

        if (result.CodeUnauthorized === 401) {
          this.loading = false
          this.$swal("Error", "Sessão Expirada", "error");

          setTimeout(() => {
            this.$router.push('/')
          }, 3000)

        }

      }
    },

    required(v) {
      return !!v || "Preencha o campo "
    },
    Emails(v) {
      if (/^[_a-z0-9-.]+@[a-z.-]+\.[a-z]+$/i.test(v)) return true
      return 'Deve ser um e-mail valido.'
    },
    Nome(v) {
      if (/[a-zA-Z\u00C0-\u00FF ]+$/i.test(v)) return true
      return 'Insira apenas letras'
    },
    letraNum(v) {
      if (/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/.test(v)) return true
      return "Senha deve conter letra e número."
    },
    Min(v) {
      if (v.length >= 8) return true
      return "Min 8 caracteres"
    },
    MinName(v) {
      if (v.length >= 3) return true
      return "Nome deve ter mais que 3 caracteres"
    },
    CpfRules(v) {
      if (validate(v)) return true
      return "CPF Invalido";
    },
    PhoneRules(v) {
      if (validator.isMobilePhone(v)) return true
      return "Número de telefone inválido."
    }
  },
}



</script>

<style scoped>
.container-title {
  font-size: xx-large;
  font-weight: bold;
  text-align: center;
}
</style>