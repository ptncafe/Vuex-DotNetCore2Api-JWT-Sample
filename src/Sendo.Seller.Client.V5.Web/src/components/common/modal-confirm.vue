<template>
  <v-layout row justify-center>
    <v-dialog v-model="isShow" persistent max-width="290">
      <v-card>
        <v-card-title class="headline" >{{data.title}}</v-card-title>
        <v-card-text>{{data.text}}</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="green darken-1" flat @click.native="hide">Đóng</v-btn>
          <!-- <v-btn color="green darken-1" flat @click.native="callback">Agree</v-btn> -->
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
export default {
  name: "common-modal-confirm",
  // data() {

  // },
  computed: {
    isShow() {
      return this.$store.state.commonModalConfirm.isShow;
    },
    data() {
      return this.$store.state.commonModalConfirm.data;
    }
  },
  methods: {
    hide: function() {
      this.$store.dispatch("hideModalConfirm");
    }
  }
};
</script>
