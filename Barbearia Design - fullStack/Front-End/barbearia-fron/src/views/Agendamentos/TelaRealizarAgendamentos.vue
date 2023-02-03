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
                                <v-text-field type="date" v-model="date"
                                    label="Informe a data para o Agendamento:"></v-text-field>
                            </v-col>

                            <v-col cols="12" md="6">
                                <v-select v-model="select" :items="items"
                                    label="Item" required
                                  ></v-select>
                            </v-col>

                            <v-col cols="12" md="6">
                                <v-select v-model="select" :items="items"
                                    label="Item" required
                                  ></v-select>
                            </v-col>



                            <v-col cols="12" md="6">
                                <v-select v-model="select" :items="items"
                                    label="Item" required
                                  ></v-select>
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
            select:null,
         items: [
        'Item 1',
        'Item 2',
        'Item 3',
        'Item 4',
      ]
        }
    }
}


</script>


<style scoped>
.container-title {
    font-size: xx-large;
    font-weight: bold;
    text-align: center;
}
</style>