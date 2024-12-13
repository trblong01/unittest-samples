import { toDto } from './get-post-query-mapper';
import { validate } from './get-post-query-validator';
import axios from 'axios';

export type GetPostQuery = Readonly<{
  id: string;
}>;

export function makeGetPostQuery({ postsRepository }: Pick<Dependencies, 'postsRepository'>) {
  return async function getPostQuery({ id }: GetPostQuery) {
    await validate({ id });

     // Make an HTTP call to the external API
     const externalApiUrl = `https://external-system.example.com/author/${id}`;
     const externalApiResponse = await axios.get(externalApiUrl);
 
     const { authorName, authorDescription } = externalApiResponse.data;
 
     // Validate the external API response
     if (!externalApiResponse.data || !authorName || !authorDescription) {
       throw new Error('Invalid author data received from the external system.');
     }

    const post = await postsRepository.getById({ id });

    if (!post) {
      return null;
    }

    return toDto(post);
  };
}
