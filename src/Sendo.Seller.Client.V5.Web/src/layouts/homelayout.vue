<template>
  <v-app id="homelayout">
    <v-content>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
					<router-view></router-view>
        </v-layout>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: "homelayout" // id of the layout
};
</script>
