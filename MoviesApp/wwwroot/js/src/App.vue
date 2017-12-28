<template>
  <div id="app" class="row">
    <movie v-on:delete-movie="deleteMovie" v-for="movie in movies" v-bind:movie="movie"></movie>
    <add-movie v-on:add-movie="addMovie"></add-movie>
  </div>
</template>
<script>
  import Movie from './components/Movie'
  import AddMovie from './components/AddMovie'
  export default {
    name: 'app',
    components: {
      Movie,
      AddMovie
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
      };
    }, methods: {
      deleteMovie(movie) {
        const movieIndex = this.movies.indexOf(movie);
        this.movies.splice(movieIndex, 1);
      },
      addMovie(movie) {
        this.movies.push({
          title: movie.title,
          year: movie.year,
          director: movie.director,
          description: movie.description,
        });
      }
    },
  }
</script>
<style lang="scss">

</style>
