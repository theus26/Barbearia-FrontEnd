<template>
    <main>
        <div class="components">
            <NavBar />
        </div>
        <br>
        <div class="dialof">
            <v-row justify="center">
                <v-dialog v-model="dialog" fullscreen :scrim="false" transition="dialog-bottom-transition">
                    <v-card>
                        <v-toolbar dark color="primary">
                            <v-btn icon dark @click="dialog = false">
                                <v-icon>mdi-close</v-icon>
                            </v-btn>
                            <v-toolbar-title>Editar Agendamento</v-toolbar-title>
                            <v-spacer></v-spacer>

                        </v-toolbar>
                        <div class="container-title">
                            <h1>Editar Agendamento</h1>
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
                                    <v-btn :loading="loading" block color="success" size="large" type="submit"
                                        variant="elevated">
                                        Editar Agendamento
                                    </v-btn>
                                </v-container>
                            </v-form>
                        </div>
                    </v-card>
                </v-dialog>
            </v-row>
        </div>
        <br>

        <div class="container">

            <div class="info" v-show="info">
                <v-alert type="warning" title="Você não possui nenhum agendamento..." text=""
                    variant="tonal"></v-alert>
            </div>


            <div class="container-header">
                <div class="img">
                    <v-img src="../../assets/img1.svg" width="60" heigth="60"></v-img>
                </div>

                <div class="containe-title">
                    Meus Agendamentos
                    <hr>
                </div>
            </div>
            <br>

            <div class="container-table">
                <v-table>
                    <thead>
                        <tr>
                            <th class="text-left">
                                Data do Agendamento
                            </th>
                            <th class="text-left fon">
                                Serviço Desejado
                            </th>
                            <th class="text-left">
                                Horário
                            </th>
                            <th class="text-left">
                                Barbeiro
                            </th>

                            <th class="text-left">
                                Ações do Agendamento
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in desserts" :key="item.Indice">

                            <td>{{ item.hairCurtDate }}</td>
                            <td>{{ item.desiredService }}</td>
                            <td>{{ item.time }}</td>
                            <td>{{ item.barber }}</td>
                            <td>
                                <div class="container-btn">
                                    <button title="Editar Agendamento" class="btn" color="sucess" @click="Editar(item)">
                                        <v-icon end icon="mdi-pencil"></v-icon>
                                    </button>
                                    <button title="Cancelar Agendamento" class="btn2" color="sucess"
                                        @click="Cancelar(item.idSchedulling)">
                                        <v-icon end icon="mdi-cancel"></v-icon>
                                    </button>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </v-table>
                <div class="container-paginatior">
                    <div class="pagination">
                        <v-pagination v-model="page" :length="6"></v-pagination>
                    </div>
                </div>
            </div>
        </div>

    </main>
</template>




<script>
import moment from 'moment'
moment.locale('pt-br');
import { UpdateScheduling } from '@/Services/Api';
import { DeleteScheduling } from '@/Services/Api'
import { GetAllPerId } from '@/Services/Api';
import NavBar from '@/components/NavBar.vue';

export default {
    name: 'TelaPrincipal',
    components: {
        NavBar,
    },

    data() {
        return {
            page: 1,
            dialog: false,
            info: false,
            barberEnum: null,
            concluido: [],
            desserts: [

            ],
            DateFormat: null,
            form: false,
            loading: null,
            date: null,
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
                'Fagner ',
                'Pedro',
                'Jõao',
            ]
        }
    },
    methods: {
        Editar(v) {
            this.dialog = true
            var user = v;
            this.concluido = user
            console.log(this.concluido)
            this.barbeiroSelect = this.concluido.barber
            this.servicoSelect = this.concluido.desiredService
            this.horarioSelect = this.concluido.time
            localStorage.setItem("IdScheduling", this.concluido.idSchedulling)

        },
        async Cancelar(v) {
            const IdScheduling = v
            const result = await DeleteScheduling(IdScheduling)
            if (result === 200) {
                this.$swal(
                    'Concluido!',
                    'Agendamento Cancelado com Sucesso.',
                    'success'
                )
            }
            else {
                this.$swal(
                    'Error!',
                    'Erro ao Cancelar agendamento.',
                    'error'
                )
            }
            this.GetallScheduling();
        },

        async onSubmit() {

            setTimeout(() => {
                this.loading = true
            }, 2000)

            const IdUser = localStorage.getItem("IdUser");
            const IdScheduling = localStorage.getItem("IdScheduling")

            if (this.barbeiroSelect == 'Jõao') {
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

            const result = await UpdateScheduling(IdUser, IdScheduling, this.date, this.servicoSelect, this.horarioSelect, this.barberEnum)
            if (result === 200) {
                this.dialog = false
                this.loading = false
                this.$swal(
                    'Concluido!',
                    'Agendamento Editado com Sucesso.',
                    'success'
                )
            }
            else {
                this.$swal(
                    'Error!',
                    'Erro ao Editar agendamento.',
                    'error'
                )
                this.dialog = false
                this.loading = false
            }

        },

        async GetallScheduling() {
            const IdUser = localStorage.getItem("IdUser");
            const result = await GetAllPerId(IdUser);

            if (result.status === 200) {

                if (result.data.count === 0) {
                    this.info = true
                }
                if (result.data.count != 0) {
                    this.info = false
                    const arr = this.desserts = result.data.schedulings
                }
            }
            else{
                if(result.code === 401){
                    
                    this.$swal(
                        'Error!',
                        'Sessão Expirada!.',
                        'error'
                    )
                    
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
    },
    mounted() {
        this.GetallScheduling();
    }

}
</script>

<style scoped>
.containe-title {
    font-size: xx-large;
    font-weight: bold;
    padding: 0.5rem;
}

.container-header {
    display: flex;
    gap: 1rem;
}

.container {
    border: 1px solid #f5f4f4;
    background-color: #f5f4f4;
    padding: 2rem 5rem 5rem;

}

.v-table {
    padding: 1.5rem;
}

.pagination {
    padding: 2rem;
}

.btn {
    margin-left: 2rem;
    color: orange;
}

.btn2 {
    margin-left: 2rem;
    color: red;
}

.txt {
    font-weight: bold;
    font-size: xx-small;
}

.dialog-bottom-transition-enter-active,
.dialog-bottom-transition-leave-active {
    transition: transform .2s ease-in-out;
}

.container-title {
    font-size: xx-large;
    font-weight: bold;
    text-align: center;
}

.container-form {
    padding: 6rem 0 0 0;
}

.info {
    padding-bottom: 2rem;
}
</style>
