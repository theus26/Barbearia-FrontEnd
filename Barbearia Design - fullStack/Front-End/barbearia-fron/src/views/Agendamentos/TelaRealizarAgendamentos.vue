<template>
    <main>
        <div class="components">
            <NavBar />
        </div>
        <br>
        <br>
        <ContainerBoxVue>
            <div class="container-title">
                <h1>Realize aqui seu Agendamento</h1>
                <hr>
                <br>
            </div>

            <div class="container-form">
                <v-form v-model="form" @submit.prevent="onSubmit">
                    <v-container>
                        <v-row>
                            <v-col cols="12" md="6">
                                <v-text-field type="date" :rules="[required]" v-model="date"
                                    label="Informe a data para o Agendamento:"></v-text-field>
                            </v-col>

                            <v-col cols="12" md="6">
                                <v-select v-model="horarioSelect" :rules="[select]" :items="itemsHorario"
                                    label="Escolha o Horário:"></v-select>
                            </v-col>

                            <v-col cols="12" md="6">
                                <v-select v-model="servicoSelect" :rules="[select]" :items="itemsServiço"
                                    label="Serviço Desejado:"></v-select>
                            </v-col>



                            <v-col cols="12" md="6">
                                <v-select v-model="barbeiroSelect" :rules="[select]" :items="itemsBarbeiro"
                                    label="Barbeiro Desejado:"></v-select>
                            </v-col>


                        </v-row>
                        <br>
                        <br>
                        <v-btn :disabled="!form" :loading="loading" block color="success" size="large" type="submit"
                            variant="elevated">
                            Realizar Agendamento
                        </v-btn>
                    </v-container>
                </v-form>
            </div>

        </ContainerBoxVue>
    </main>
</template>


<script>
import { RegisterScheduling } from '@/Services/Api'
import ContainerBoxVue from '@/components/ContainerBox.vue';
import NavBar from '@/components/NavBar.vue';
export default {
    name: 'TelaPrincipal',
    components: {
        NavBar,
        ContainerBoxVue
    },

    data() {
        return {
            form: false,
            date: '',
            barberEnum: null,
            horarioSelect: null,
            servicoSelect: null,
            barbeiroSelect: null,
            loading: null,
            itemsHorario: [
                '08:00',
                '09:00',
                '10:00',
                '11:00',
                '12:00',
                '14:00',
                '15:00',
                '16:00',
                '17:00',
                '18:00',
                '19:00'
            ],
            itemsServiço: [
                'Corte de Cabelo',
                'Sombrancelha',
                'Barba',
                'Corte de Cabelo e Sombrancelha',
                'Corte de Cabelo e Barba',
                'Corte de Cabelo, Sombrancelha e Barba',
                'Sombrancelha e Barba'
            ],
            itemsBarbeiro: [
                'Fagner',
                'Pedro',
                'Jõao',

            ]
        }
    },
    methods: {
        async onSubmit() {
            if (!this.form) return
            setTimeout(() => {
                this.loading = true
            }, 2000)
            const UserId = localStorage.getItem("IdUser")
            if (this.barbeiroSelect == 'Fagner') {
                this.barberEnum = 0;
            }
            else {
                if (this.barbeiroSelect == 'Pedro') {
                    this.barberEnum = 1;
                }
                else {
                    this.barberEnum = 2
                }
            }

            const result = await RegisterScheduling(UserId, this.date, this.servicoSelect, this.horarioSelect, this.barberEnum)
            if (result.status === 200) {
                this.loading = false
                this.$swal("Sucesso", "Agendado com sucesso!", "success");
                this.$router.push("/TelaMeusAgendamentos")
            }

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

    select(value) {
        if (value) return true

        return 'Select an item.'
    },
    required(v) {
        return !!v || "Preencha o campo "
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