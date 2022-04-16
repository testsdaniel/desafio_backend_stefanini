<template>
	<v-container
    class="py-8 px-6"
    fluid
	>
		<v-row>
			<h1>City page</h1>
		</v-row>
	</v-container>
</template>
<script>
import ApiService from "../services/ApiService";
export default {
	data: () => ({}),
  mounted() {
    ApiService.getAll('/City')
  }
}
</script>
