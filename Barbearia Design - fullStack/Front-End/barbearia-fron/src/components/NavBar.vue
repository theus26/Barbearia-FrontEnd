<template>
    <div class="container-main">
        <div class="contaienr">
            <div title="Clique aqui!" class="container-geral">
                <div class="container-menu" @click="appear">
                    <div class="container-svg">
                        <v-img class="image" src="../assets/img4.svg" alt="Calendar" width="30" heigth="30"></v-img>
                    </div>
                    <div class="container-title">
                        <span class="txt">
                            Meus Serviços
                        </span>
                    </div>
                </div>
                <div class="dropdown-content" v-show="disappear">
                        <button  title="Seus Agendamentos" @click="Mys" id="logout" v-show="meus">Meus Agendamentos</button>
                        <hr>
                        <button title="Todos Agendamentos" @click="all" id="logout" v-show="todos">Todos Agendamentos</button>
                        <hr>
                        <button title="Realizar agendamento" @click="perform" id="logout" v-show="efetuar">Realizar Agendamento</button>
                        <hr>
                        <button title="Editar Usuario" @click="Edit" id="logout" v-show="editar">Editar Usuario</button>
                    </div>
            </div>

            <div class="container-button">
                <div title="Deseja sair, clique aqui" class="dropdown">
                    <button class="dropbtn" @click="aparece"><v-icon id="icon">mdi-logout</v-icon></button>
                    <div class="dropdown-content" v-show="some">
                        <button @click="Logout" id="logout">SAIR</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
  
  
<script>
import { Logout } from '@/Services/Api';
export default {
    name: "ButtonLogout",
    data() {
        return {
            some: false,
            disappear:false,
            meus: false,
            todos: false,
            efetuar:false,
            editar: false
        }

    },
    props: ['show'],
    methods: {
        aparece() {
            this.some = !this.some
        },
        appear(){
            this.disappear = !this.disappear
        },
        Mys(){
            setTimeout(() => (this.$router.push('/TelaMeusAgendamentos')), 500)
        },
        all(){
            setTimeout(() => (this.$router.push('/TelaAllAgendamentos')), 500)
        },
        perform(){
            setTimeout(() => (this.$router.push('/TelaRealizarAgendamentos')), 500)
        },
        Edit(){
            setTimeout(() => (this.$router.push('/EditarUsuario')), 500)
        },
        seeIsAdmin(){
            const Admin = localStorage.getItem("Admin")
            if (Admin == 'true'){
                this.todos = true
                this.editar = true
            }
            else{
                this.todos = false
                this.meus = true
                this.efetuar = true
                this.editar = true
            }

        },

        async Logout() {
            const IdUser = localStorage.getItem("IdUser")
            const Token = localStorage.getItem("Token")
            const result = await Logout (IdUser, Token)
            if (result === 200){
                localStorage.clear()
                setTimeout(() => (this.$router.push('/')), 1500)
            }
            else{
                this.$swal("Error", "Error ao sair", "error")
            }
        },
    },
    mounted(){
        this.seeIsAdmin();
    }
};
</script>
  
<style scoped>
.contaienr {
    display: flex;
    justify-content: flex-end;
    margin-top: -85px;
    gap: 1rem;
}

/* Style The Dropdown Button */
.dropbtn {
    background-color: #D9D9D9;
    color: #000000;
    padding: 20px;
    font-size: 16px;
    border: none;
    cursor: pointer;
    border-radius: 50px;
}

/* The container <div> - needed to position the dropdown content */
.dropdown {
    position: relative;
    display: inline-block;
}

/* Dropdown Content (Hidden by Default) */
.dropdown-content {
    display: none;
    position: absolute;
    font-weight: bold;
    color: black;
    box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
    z-index: 1;
    margin-left: -5px;
}

/* Links inside the dropdown */

/* Show the dropdown menu on hover */
.dropdown-content {
    display: block;
}

#logout:hover {
    background-color: #0b0909;
    color: #ffffff;

}

#logout {
    padding: 1rem;
}

.container-geral{
    border: 1px solid #00B49C;
    border-radius: 15px;
    width: 11rem;
    height: 100%;
    background-color: #00B49C;
    margin-top: 0.5rem;
}
.container-menu{
    display: flex;
    align-items: center;
    gap: 1rem;
    padding: 0.5rem;
    cursor: pointer;
}
.txt{
    font-size: medium;
    font-weight: bold;
}

@media (max-width: 599px) {
  .container-geral {
   display: none;
  }
 
}
</style>

   
