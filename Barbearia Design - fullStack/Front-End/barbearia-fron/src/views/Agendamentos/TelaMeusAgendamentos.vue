<template>
    <main>
        <div class="components">
            <NavBar />
        </div>

        <br>

        <div class="containe-title">
            Meus Agendamentos
            <hr>
        </div>
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
                        <td>{{ item.DatadoAgendamento }}</td>
                        <td>{{ item.ServiçoDesejado }}</td>
                        <td>{{ item.Horario }}</td>
                        <td>{{ item.Barbeiro }}</td>
                        <td>
                            <div class="container-btn">
                                <button title="Editar Agendamento" class="btn" color="sucess"
                                    @click="Concluir(item.Indice)">
                                    <v-icon end icon="mdi-pencil"></v-icon>
                                </button>
                                <button title="Cancelar Agendamento" class="btn2" color="sucess"
                                    @click="Cancelar(item.Indice)">
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
    </main>
</template>


<script>

import NavBar from '@/components/NavBar.vue';
export default {
    name: 'TelaPrincipal',
    components: {
        NavBar
    },

    data() {
        return {
            page: 1,
            concluido: [],
            desserts: [
                {
                    Indice: 1,
                    Cliente: 'Matheus Filipe',
                    DatadoAgendamento: '03/02/2023',
                    ServiçoDesejado: 'Corte de cabelo, Sombrancelha e Barba',
                    Horario: '08:00h ',
                    Barbeiro: 'Fagner'
                },
                {
                    Indice: 2,
                    Cliente: 'Gabriel Filipe',
                    DatadoAgendamento: '04/02/2023',
                    ServiçoDesejado: 'Corte de cabelo, Sombrancelha',
                    Horario: '09:00h ',
                    Barbeiro: 'Pedro'
                },
                {
                    Indice: 3,
                    Cliente: 'Pedro Filipe',
                    DatadoAgendamento: '05/02/2023',
                    ServiçoDesejado: 'Corte de cabelo e Barba',
                    Horario: '10:00h ',
                    Barbeiro: 'Fagner'
                },
                {
                    Indice: 4,
                    Cliente: 'Jõao Filipe',
                    DatadoAgendamento: '06/02/2023',
                    ServiçoDesejado: 'Sombrancelha e Barba',
                    Horario: '11:00h ',
                    Barbeiro: 'Pedro'
                },
            ],
        }
    },
    methods: {
        Concluir(v) {

            this.$swal({
                title: 'Concluir Agendamento?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sim, Concluir!'
            }).then((result) => {
                if (result.isConfirmed) {
                    this.$swal(
                        'Concluido!',
                        'Agendamento Concluido com Sucesso.',
                        'success'
                    )
                }
            })
        },
        Cancelar(v) {
            this.$swal({
                title: 'Cancelar Agendamento?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sim, Cancelar!'
            }).then((result) => {
                if (result.isConfirmed) {
                    this.$swal(
                        'Concluido!',
                        'Agendamento Cancelado com Sucesso.',
                        'success'
                    )
                }
            })
        }
    }
}


</script>


<style scoped>
.containe-title {
    font-size: xx-large;
    font-weight: bold;
    padding: 1.5rem;
    text-align: center;
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

</style>