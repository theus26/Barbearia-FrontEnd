<template>
    <main>
        <div class="components">
            <NavBar />
        </div>
        <br>

        <div class="container">

            <div class="container-header">
                <div class="img">
                    <v-img src="../../assets/agenda.svg" width="60" heigth="60"></v-img>
                </div>

                <div class="containe-title">
                    Todos Agendamentos
                    <hr>
                </div>
            </div>
            <br>

            <div class="container-table">
                <v-table>
                    <thead>
                        <tr>
                            <th class="text-left">
                                <p class="txt">Cliente</p>
                            </th>
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

                            <td>{{ item.nameUser }}</td>
                            <td>{{ item.hairCurtDate }}</td>
                            <td>{{ item.desiredService }}</td>
                            <td>{{ item.time }}</td>
                            <td>{{ item.barber }}</td>
                            <td>
                                <div class="container-btn">
                                    <button title="Concluir Agendamento" class="btn" color="sucess"
                                        @click="Concluir(item, item.idSchedulling)">
                                        <v-icon end icon="mdi-checkbox-marked-circle"></v-icon>
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
import { DeleteScheduling } from '@/Services/Api'
import { CompleteScheduling } from '@/Services/Api'
import { GetAll } from '@/Services/Api';
import NavBar from '@/components/NavBar.vue';
import ContainerBox from '@/components/ContainerBox.vue';
export default {
    name: 'TelaPrincipal',
    components: {
        NavBar,
        ContainerBox
    },

    data() {
        return {
            page: 1,
            concluido: [],
            desserts: [

            ],
        }
    },
    methods: {
        async Concluir(v, i) {
            const IdScheduling = i
            const SchedulingCompleted = true

            const result = await CompleteScheduling(IdScheduling, SchedulingCompleted);
            if (result === 200) {
                const arr = this.desserts;
                const Indice = arr.indexOf(v)
                const remove = arr.splice(Indice, 1)

                this.$swal(
                    'Concluido!',
                    'Agendamento Concluido com Sucesso.',
                    'success'
                )
            }
            else {
                this.$swal(
                    'Error!',
                    'Não foi possivel Concluir agendamento.',
                    'error'
                )
            }

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
            this.GetAllScheduling();
        },

        async GetAllScheduling() {
            const result = await GetAll()
            if (result.status === 200) {
                const agen = this.desserts = result.data.schedulings

                agen.sort(function (a, b) {
                    if (a.hairCurtDate < b.hairCurtDate) {
                        return -1
                    }
                    else {
                        return true
                    }
                })
                

            }
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




    mounted() {
        this.GetAllScheduling();
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
    color: green;
}

.btn2 {
    margin-left: 2rem;
    color: red;
}

.txt {
    font-weight: bold;
    font-size: xx-small;
}
</style>