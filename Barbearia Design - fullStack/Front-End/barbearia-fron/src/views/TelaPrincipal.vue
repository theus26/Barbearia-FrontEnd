<template>
    <main>
    <NavBar />
    <br>
    <br>
    <ContainerBox>
        <div class="containe-title">
            Seja Bem Vindo, {{ user }}
            <hr>
        </div>
        <div class="container-all">
            <div class="containe-cards">
                <div class="contaienr">
                    <div title="Clique aqui!" class="container-geral">
                        <div class="container-menu" @click="Mys">
                            <div class="container-svg">
                                <v-img class="image" src="../assets/img1.svg" alt="Calendar" width="70" heigth="70"></v-img>
                            </div>
                            <div class="container-title">
                                <span class="txt">
                                    Meus Agendamentos
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    
            <div class="containe-cards">
                <div class="contaienr">
                    <div title="Clique aqui!" class="container-geral">
                        <div class="container-menu" @click="all">
                            <div class="container-svg">
                                <v-img class="image" src="../assets/img4.svg" alt="Calendar" width="70" heigth="70"></v-img>
                            </div>
                            <div class="container-title">
                                <span class="txt">
                                    Todos Agendamentos
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    
            <div class="containe-cards">
                <div class="contaienr">
                    <div title="Clique aqui!" class="container-geral" @click="perform">
                        <div class="container-menu" >
                            <div class="container-svg">
                                <v-img class="image" src="../assets/img3.svg" alt="Calendar" width="70" heigth="70"></v-img>
                            </div>
                            <div class="container-title">
                                <span class="txt realizar">
                                    Efetuar Agendamentos
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContainerBox>
    </main>
</template>


<script>
import ContainerBox from '@/components/ContainerBox.vue';
import NavBar from '@/components/NavBar.vue';
export default{
    name:'TelaPrincipal',
    components:{
        NavBar,
        ContainerBox
    },

    data(){
        return{
            user:'Admin'
        }
    },

    methods:{
        Mys(){
            setTimeout(() => (this.$router.push('/TelaMeusAgendamentos')), 500)
        },
        all(){
            setTimeout(() => (this.$router.push('/TelaAllAgendamentos')), 500)
        },
        perform(){
            setTimeout(() => (this.$router.push('/TelaRealizarAgendamentos')), 500)
        },
    }
    
}


</script>

<style scoped>
.containe-title{
    font-size: xx-large;
    font-weight: bold;
    padding-bottom: 2.5rem;
}

.container-geral{
    border: 1px solid #00B49C;
    border-radius: 15px;
    width: 18rem;
    height: 100%;
    background-color: #00B49C;
    margin-top: 0.5rem;
    cursor: pointer;
}
.container-menu{
    display: flex;
    align-items: center;
    gap: 1.5rem;
    padding: 0.5rem;
}
.txt{
    font-size: medium;
    font-weight: bold;
    text-align: center;
}

.container-all{
    display: flex;
    justify-content: space-between;
    padding-bottom: 10rem;
}

@media (max-width: 599px) {
    .container-all {
      flex-direction: column;
    }
    .image{
        width: 60px;
        height: 60px;
    }

    .container-geral{
        height: 50%;
    }
    .container-svg{
        margin-top: 15px;
    }
  
  }
</style>