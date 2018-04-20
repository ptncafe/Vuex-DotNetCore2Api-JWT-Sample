<template>
 <v-flex xs12 sm8 md4>
            <v-card class='elevation-12'>
              <v-toolbar dark color='primary'>
                <v-toolbar-title>Login form</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-tooltip bottom>
                  <v-btn
                    icon
                    large
                    <!-- :href='source' -->
                    target='_blank'
                    slot='activator'
                  >
                    <v-icon large>code</v-icon>
                  </v-btn>
                  <span>Source</span>
                </v-tooltip>

              </v-toolbar>
              <v-card-text>
                <v-form @submit.prevent="login()">
                  <v-text-field prepend-icon='person' name='login' label='Login' type='text' v-model='username'></v-text-field>
                  <v-text-field prepend-icon='lock' name='password' label='Password' id='password' type='password' v-model='password'></v-text-field>
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color='primary' v-on:click="login">Login</v-btn>
              </v-card-actions>
            </v-card>
          </v-flex>
</template>

<script>
// import { mapGetters, mapActions } from 'vuex';

export default {
  data() {
    return {
      username: "",
      password: ""
    };
  },
  methods: {
    login() {
      this.$store
        .dispatch("login", {
          username: this.username,
          password: this.password
        })
        .then(res => {
          this.$router.push("/");
        });
    }
  }
};
</script>
