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
export default {
	data: () => ({
      cards: ['Today', 'Yesterday'],
      drawer: null,
      links: [
        ['mdi-inbox-arrow-down', 'Inbox'],
        ['mdi-send', 'Send'],
        ['mdi-delete', 'Trash'],
        ['mdi-alert-octagon', 'Spam'],
      ],
    }),
}
</script>
