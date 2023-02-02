<template>
  <main>
    <ContainerBox>
      <div class="container-title">
        <h1>Realize aqui seu cadastro</h1>
      </div>

      <div class="container-form">
        <v-form v-model="form" @submit.prevent="onSubmit">
          <v-container>
            <v-row>
              <v-col cols="12" md="15">
                <v-text-field v-model="firstname" maxlength="30" :rules=[required,Nome,MinName] :counter="10" label="Informe seu Nome"
                  ></v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12" md="6">
                <v-text-field v-model="phone" v-mask="['(##) ####-####', '(##) #####-####']" :readonly="loading" :rules="[required,PhoneRules]" label="Informe seu telefone" 
                  placeholder="Ex: 7998869-2589" ></v-text-field>
              </v-col>

              <v-col cols="12" md="6">
                <v-text-field v-model="cpf" v-mask="'###.###.###-##'" :readonly="loading" :rules="[required,CpfRules]" label="Informe seu CPF" 
                  placeholder="Ex: 000.000.000-00"></v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12" md="6">
                <v-text-field v-model="email" :readonly="loading" :rules="[required, Email]" label="Informe seu E-mail" 
                  placeholder="Ex: joao@gmail.com"></v-text-field>
              </v-col>

              <v-col cols="12" md="6">
                <v-text-field  :append-icon="show4 ? 'mdi-eye' : 'mdi-eye-off'" :type="show4 ? 'text' : 'password'" @click:append="show4 = !show4" v-model="password" :readonly="loading" :rules="[required,Min,letraNum]" :counter="8" label="Informe a sua Senha"
                ></v-text-field>
              </v-col>
            </v-row>
            <br>
            <br>
            <v-btn :disabled="!form" :loading="loading" block color="success" size="large" type="submit"
              variant="elevated">
              Realizar Cadastro
            </v-btn>
          </v-container>
        </v-form>
      </div>

    </ContainerBox>

  </main>
</template>

<script>
import { validate } from "gerador-validador-cpf";
import validator from 'validator';
import ContainerBox from '../components/ContainerBox.vue'

export default {
  name: 'TelaCadastro',
  components: {
    ContainerBox
  },
  data: () =>({
    show4: false,
    form: false,
    valid: false,
    firstname:null,
    email: '',
    password: '',
    cpf: '',
    phone: '',
    loading:null,
  }),

  methods: {

    onSubmit() {
      if (!this.form) return
      setTimeout(() =>{
        this.loading = true
      },2000)
      setTimeout(() =>{
        this.loading = false
        this.$swal("Sucesso", "Usuario cadastrado com sucesso!", "success");  
      },4000)
      setTimeout(() => {
        this.$router.push('/')
      }, 6000);
      const obj = {
        email: this.email,
        senha: this.password
      }
      console.log(obj)
      
    },

    required(v) {
      return !!v || "Preencha o campo "
    },
    Email(v) {
      if (/^[_a-z0-9-]+@[a-z.-]+\.[a-z]+$/i.test(v)) return true
      return 'Deve ser um e-mail valido.'
    },
    Nome(v){
      if (/[a-zA-Z\u00C0-\u00FF ]+$/i.test(v)) return true
      return 'Insira apenas letras'
    },
    letraNum(v){
      if (/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/.test(v)) return true
      return "Senha deve conter letra e número."
    },
    Min(v){
      if (v.length >= 8 ) return true
      return "Min 8 caracteres"
    },
    MinName(v){
      if (v.length >= 3 ) return true
      return "Nome deve ter mais que 3 caracteres"
    },
    CpfRules(v){
       if(validate(v)) return true
      return "CPF Invalido";
    },
    PhoneRules(v){
      if(validator.isMobilePhone(v)) return true
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