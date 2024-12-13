
// import { PostsRepository } from '@application/common/interfaces/posts-repository';
// import { toDto } from '@application/posts/queries/get-post/get-post-query-mapper';
import { ValidationException } from '@application/common/exceptions';
import { validate } from '@application/posts/queries/get-post/get-post-query-validator';
// import { Post } from '@domain/entities/post';
import axios from 'axios';

import { makeGetPostQuery } from '../../../../../src/application/posts/queries/get-post/get-post-query';
jest.mock('axios');
// jest.mock('../../../../../src/application/posts/queries/get-post/get-post-query-validator',() => ({
//   validate: jest.fn(),
// }));
// jest.mock('../../../../../src/application/posts/queries/get-post-query-mapper',() => ({
//   toDto: jest.fn(),
// }));

describe('makeGetPostQuery', () => {
  const postsRepository = {
    getById: jest.fn(),
    create: jest.fn(), // Mocking the 'create' method
    delete: jest.fn(), // Mocking the 'delete' method
    list: jest.fn(),   // Mocking the 'list' method
  };

  
  const getPostQuery = makeGetPostQuery({ postsRepository });

  beforeEach(() => {
    jest.clearAllMocks();
  });

  describe('Validation', () => {
    it('should validate the input', async () => {
      const id = '123';
      (axios.get as jest.Mock).mockResolvedValue({ data: { authorName: 'John Doe', authorDescription: 'Author Description' } });
      postsRepository.getById.mockResolvedValue({});

      expect(getPostQuery({ id })).rejects.toThrow(ValidationException);
    });
  });

  describe('External API Call', () => {
    it('should throw an error if external API returns invalid data', async () => {
      const id = '907b0a0b-9a12-4073-ab27-3ad5927955e9';
      (axios.get as jest.Mock).mockResolvedValue({ data: { authorName: null } });

      await expect(getPostQuery({ id })).rejects.toThrow('Invalid author data received from the external system.');
    });
  });

  describe('Repository Interaction', () => {
    it('should return null if the post does not exist', async () => {
      const id = '907b0a0b-9a12-4073-ab27-3ad5927955e9';
      (axios.get as jest.Mock).mockResolvedValue({ data: { authorName: 'John Doe', authorDescription: 'Author Description' } });
      postsRepository.getById.mockResolvedValue(null);

      const result = await getPostQuery({ id });

      expect(result).toBeNull();
    });

    it('should return the post DTO if the post exists', async () => {
      const id = '907b0a0b-9a12-4073-ab27-3ad5927955e9';
      const post = { id: '907b0a0b-9a12-4073-ab27-3ad5927955e9', title: 'Post Title' };
      // const postDto = new Post({ id: '907b0a0b-9a12-4073-ab27-3ad5927955e9', createdAt: new Date(2022, 1, 1), title: 'Post Title DTO'  });

      (axios.get as jest.Mock).mockResolvedValue({ data: { authorName: 'John Doe', authorDescription: 'Author Description' } });
      postsRepository.getById.mockResolvedValue(post);
      // (toDto.mockReturnValue(postDto);

      const result = await getPostQuery({ id });

      expect(result).toEqual(post);
      
    });
  });
});