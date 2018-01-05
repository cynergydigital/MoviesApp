<template>
  <div class="col-sm-4">
    <div class="card mt-3">
      <!--<img src="http://placehold.it/544x800/" alt="Movie Poster" class="card-img-top" />-->
      <div class="card-body">
        <h4 class="card-title">{{movie.title}}</h4>
        <h6 class="card-subtitle mb-2 text-muted">{{movie.year}} - {{movie.director}}</h6>
        <p class="card-text">
          {{movie.description}}
        </p>
        <button class="btn btn-primary" v-on:click="editMovie(movie.id)">Edit</button>
        <button class="btn btn-secondary" v-on:click="deleteMovie(movie.id)">Delete</button>
        <!--<button class="btn btn-primary" v-on:click="editMovie(movie)">Edit</button>
        <button class="btn btn-secondary" v-on:click="deleteMovie(movie)">Delete</button>-->
      </div>
    </div>
  </div>
</template>
<script type="text/javascript">
  export default {
    props: ['movie'],
    methods: {
      //deleteMovie(movie) {
      //  this.$emit('delete-movie', movie);
        deleteMovie(id) {
          this.$emit('delete-movie', id);
      },
      //editMovie(movie) {
      //  this.$emit('edit-movie', movie);
        editMovie(id) {
          this.$emit('edit-movie', id);
      },
    },
  };
</script>
<style lang="scss"></style>
