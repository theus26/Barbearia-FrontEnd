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
                <v-alert type="warning" title="Você não possui nenhum agendamento..." text="" variant="tonal"></v-alert>
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
import { GetHoraries } from '@/Services/Api';
import { GetServices } from '@/Services/Api';
import { GetShavyes } from '@/Services/Api';
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

            ],
            itemsServiço: [

            ],
            itemsBarbeiro: [

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
            var result = await DeleteScheduling(IdScheduling)
            this.$swal({
                title: 'Tem Certeza?',
                text: "Você não será capaz de reverter isso!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sim, Cancelar !',
                cancelButtonText: 'Não !',
                reverseButtons: true
            }).then((res) => {
                if (res.isConfirmed) {
                    if (result === 200) {
                        setTimeout(() => {
                            this.$swal(
                                'Cancelado!',
                                'Seu Horario foi cancelado.',
                                'success'
                            )
                        }, 2000)

                    }
                    else {
                        this.$swal(
                            'Error!',
                            'Erro ao Cancelar agendamento.',
                            'error'
                        )
                    }
                }
                console.log("Executou")
                this.GetallScheduling();
                console.log("Executou")

            })
            console.log("Executou")
            this.GetallScheduling();
            console.log("Executou")

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
            console.log(result.data.length)
            if (result.status === 200) {

                if ( result.data.length === 0) {
                    console.log("Entrou")
                    this.info = true
                }
                if (result.data[0].count != 0) {
                    this.info = false
                    const arr = this.desserts = result.data
                    //Ordendado array pelas datas mais recentes
                    arr.sort(function (a, b) {
                        if (a.hairCurtDate < b.hairCurtDate) {
                            return -1
                        }
                        else {
                            return true
                        }
                    })
                }
            }
            else {
                if (result.code === 401) {

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

        async GetAllHoraries() {

            const result = await GetHoraries();
            if (result.status === 200) {

                const data = result.data;
                const hr = data.map(data => data.horary)
                this.itemsHorario = hr
            }
            else {
                console.log("Não foi possivel")
            }
        },

        async GetAllServices() {
            const result = await GetServices();

            if (result.status === 200) {
                const data = result.data;
                const service = data.map(data => data.nameServices);
                this.itemsServiço = service;

            } else {
                console.log("Não foi possivel")
            }
        },

        async GetAllShavyes() {
            const result = await GetShavyes();
            if (result.status === 200) {
                const data = result.data;
                const Barbers = data.map(data => data.barberName)
                this.itemsBarbeiro = Barbers;
            } else {
                console.log("Não foi possivel");
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
        this.GetAllHoraries();
        this.GetAllServices();
        this.GetAllShavyes();
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
