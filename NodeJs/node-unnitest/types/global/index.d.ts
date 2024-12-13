import { JsonSchemaToTsProvider } from '@fastify/type-provider-json-schema-to-ts';
import {
  FastifyBaseLogger,
  FastifyInstance,
  RawReplyDefaultExpression,
  RawRequestDefaultExpression,
  RawServerDefault,
} from 'fastify';

import { Dependencies as InfrastructureDependencies } from '../../src/infrastructure/di';

declare global {
  // Declare global DI container type
  type Dependencies = InfrastructureDependencies;

  // Ensures HTTP request is strongly typed from the schema
  type FastifyRouteInstance = FastifyInstance<
    RawServerDefault,
    RawRequestDefaultExpression<RawServerDefault>,
    RawReplyDefaultExpression<RawServerDefault>,
    FastifyBaseLogger,
    JsonSchemaToTsProvider
  >;
}

// Strongly Type DI container
declare module '@fastify/awilix' {
  interface Cradle extends Dependencies {}

  interface RequestCradle extends Dependencies {}
}
