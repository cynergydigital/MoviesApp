<template>
  <div>
    <div class="row">
      <div class="col mt-3">
        <button class="btn btn-primary" v-on:click="openAddModal">Add Movie</button>
      </div>
    </div>
    <div class="row">
      <movie v-on:delete-movie="deleteMovie" v-on:edit-movie="editMovie" v-for="movie in movies" v-bind:movie="movie"></movie>
      <add-movie v-if="showAddModal" v-bind:movie="movieToAdd" v-on:close-add-modal="closeAddModal" v-on:save-movie-add="saveMovieAdd"></add-movie>
      <edit-movie v-if="showEditModal" v-bind:movie="movieToEdit" v-on:close-edit-modal="closeEditModal" v-on:save-movie-edit="saveMovieEdit"></edit-movie>
    </div>
  </div>
</template>
<script>
  import Movie from './components/Movie'
  import AddMovie from './components/AddMovie'
  import EditMovie from './components/EditMovie'
  export default {
    name: 'app',
    components: {
      Movie,
      AddMovie,
      EditMovie
    },
    data() {
      return {
        movies: [
          {
            title: 'Star Wars - The Last Jedi',
            year: '2017',
            director: 'Rian Johnson',
            description: 'Rey develops her newly discovered abilities with the guidance of Luke Skywalker, who is unsettled by the strength of her powers. Meanwhile, the Resistance prepares for battle with the First Order.'
          },
          {
            title: 'Blade Runner 2049',
            year: '2017',
            director: 'Denis Villeneuve',
            description: 'A young blade runner\'s discovery of a long-buried secret leads him to track down former blade runner Rick Deckard, who\'s been missing for thirty years.'
          },
          {
            title: 'Logan',
            year: '2017',
            director: 'James Mangold',
            description: 'In the near future, a weary Logan cares for an ailing Professor X, somewhere on the Mexican border. However, Logan\'s attempts to hide from the world, and his legacy, are upended when a young mutant arrives, pursued by dark forces.'
          },
          {
            title: 'Justice League',
            year: '2017',
            director: 'Zack Snyder',
            description: 'Fueled by his restored faith in humanity and inspired by Superman\'s selfless act, Bruce Wayne enlists the help of his newfound ally, Diana Prince, to face an even greater enemy.'
          },
          {
            title: 'Thor: Ragnarok',
            year: '2017',
            director: 'Taika Waititi',
            description: 'Imprisoned, the mighty Thor finds himself in a lethal gladiatorial contest against the Hulk, his former ally. Thor must fight for survival and race against time to prevent the all-powerful Hela from destroying his home and the Asgardian civilization.'
          },
        ],
        movieToEdit: {
          title: '',
          year: '',
          director: '',
          description: ''
        },
        editMovieIndex: 0,
        showEditModal: false,
        movieToAdd: {
          title: '',
          year: '',
          director: '',
          description: ''
        },
        showAddModal: false
      };
    }, methods: {
      deleteMovie(movie) {
        const movieIndex = this.movies.indexOf(movie);
        this.movies.splice(movieIndex, 1);
      },
      editMovie(movie) {
        this.movieToEdit = {
          title: movie.title,
          year: movie.year,
          director: movie.director,
          description: movie.description
        };
        this.showEditModal = true;
        this.editMovieIndex = this.movies.indexOf(movie);
      },
      closeEditModal() {
        this.showEditModal = false;
        this.movieToEdit = {
          title: '',
          year: '',
          director: '',
          description: ''
        };
      },
      saveMovieEdit() {
        this.movies[this.editMovieIndex] = this.movieToEdit;
        this.closeEditModal();
      },
      openAddModal() {
        this.showAddModal = true;
      },
      closeAddModal() {
        this.showAddModal = false;
        this.movieToAdd = {
          title: '',
          year: '',
          director: '',
          description: ''
        };
      },
      saveMovieAdd() {
          this.movies.push(this.movieToAdd);
      },
    },
  }
</script>
<style lang="scss">

</style>
