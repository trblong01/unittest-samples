INSERT INTO gemba.tenant (tenant_id, tenant_name)
VALUES
    ('gemba', 'Gemaba Issue Management'),
    ('iam', 'Identity & Access Management');

INSERT INTO gemba.permission_identity (id)
VALUES
    ('129d211d-d4c9-47d6-b4e9-9251e7b3e129'),
    ('a7c91ca5-70a3-4ba9-b4f0-b3a92112686e'),
    ('c037162f-8e92-4ebb-9c07-f9912833176f');

INSERT INTO gemba.client (client_id, activated, client_name, client_secret, grant_types, is_root, pi_id)
VALUES
    ('e1a2e8fa-6f74-457b-ae89-35bc6e4277ca', 'true', 'IAM', '4f49e750-87f6-4e98-8f8d-0968219f6d64', 'client_credentials', 'true', 'a7c91ca5-70a3-4ba9-b4f0-b3a92112686e');

INSERT INTO gemba.user_tbl (user_id, deleted, full_name, identity_provider_type, phone_number, status, username, pi_id)
VALUES
    ('129acab2-d937-4c43-8a22-3c269cd7f129', 'false', 'admin', 'LOCAL', '0123456789', 'ACTIVE', 'admin', '129d211d-d4c9-47d6-b4e9-9251e7b3e129');

INSERT INTO gemba.user_account (id, status, identity_provider_type, pwd_reset, is_root, last_password_updated_at, password, username, pi_id, user_id)
VALUES
    ('10c46776-9a5b-4b18-9f40-db22f0ffbd8f', 'ACTIVE', 'LOCAL', 'false', 'false', '2022-11-09 13:43:10.489392', '$2a$10$yBnu0FpTlZcs6CJm3dbu2OaV0gs3cF42raD0uBd6R4DAlg1KGM8AO', 'admin', '129d211d-d4c9-47d6-b4e9-9251e7b3e129', '129acab2-d937-4c43-8a22-3c269cd7f129');

INSERT INTO gemba.group_policy (id, group_type, policy_code)
VALUES
    ('e1a211fa-6f74-457b-ae89-35bc6e427701', 'ADMIN', 'ADMIN');

INSERT INTO gemba.resource (resource_code, tenant_id, resource_name, display)
VALUES
    ('iam/authority', 'iam', 'IAM - Authority', 'false'),
    ('iam/client', 'iam', 'IAM - Client', 'false'),
    ('iam/group', 'iam', 'Quản lý nhóm', 'true'),
    ('iam/pi-policy', 'iam', 'IAM - Pi policy', 'false'),
    ('iam/policy', 'iam', 'Quản lý phân quyền', 'true'),
    ('iam/resource', 'iam', 'IAM - Resource', 'false'),
    ('iam/resource-scope', 'iam', 'IAM - Resource Scope', 'false'),
    ('iam/tenant', 'iam', 'IAM - Tenant', 'false'),
    ('iam/user', 'iam', 'Thông tin người dùng', 'true'),
    ('iam/user-group', 'iam', 'IAM - User Group', 'false');

INSERT INTO gemba.resource_scope (scope, scope_name, resource_code, tenant_id)
VALUES
    ('view', 'Get authority', 'iam/authority','iam'),
    ('view', 'Get client', 'iam/client','iam'),
    ('create', 'Create client', 'iam/client','iam'),
    ('view', 'Get group', 'iam/group','iam'),
    ('create', 'Create group', 'iam/group','iam'),
    ('update', 'Update group', 'iam/group','iam'),
    ('create', 'Create group', 'iam/pi-policy','iam'),
    ('view', 'Get policy', 'iam/policy','iam'),
    ('create', 'Create policy', 'iam/policy','iam'),
    ('delete', 'delete policy', 'iam/policy','iam'),
    ('update', 'update policy', 'iam/policy','iam'),
    ('create', 'create resource', 'iam/resource','iam'),
    ('view', 'view resource', 'iam/resource','iam'),
    ('update', 'update resource', 'iam/resource','iam'),
    ('create', 'create resource-scope', 'iam/resource-scope','iam'),
    ('view', 'view resource-scope', 'iam/resource-scope','iam'),
    ('update', 'update resource-scope', 'iam/resource-scope','iam'),
    ('create', 'create tenant', 'iam/tenant','iam'),
    ('view', 'view tenant', 'iam/tenant','iam'),
    ('update', 'update tenant', 'iam/tenant','iam'),
    ('view', 'Get user', 'iam/user','iam'),
    ('create', 'Create user', 'iam/user','iam'),
    ('delete', 'delete user', 'iam/user','iam'),
    ('update', 'update user', 'iam/user','iam'),
    ('view', 'Get user-group', 'iam/user-group','iam'),
    ('create', 'Create user-group', 'iam/user-group','iam'),
    ('delete', 'delete user-group', 'iam/user-group','iam'),
    ('update', 'update user-group', 'iam/user-group','iam');
----    ('view', 'View order', 'vwm/order','vwm'),
----    ('create', 'Create order', 'vwm/order','vwm'),
----    ('delete', 'Delete order', 'vwm/order','vwm'),
----    ('update', 'Update order', 'vwm/order','vwm'),
----    ('approve', 'Approve order', 'vwm/order','vwm'),
----    ('view', 'View supplies', 'vwm/supplies','vwm'),
----    ('create', 'Create supplies', 'vwm/supplies','vwm'),
----    ('delete', 'Delete supplies', 'vwm/supplies','vwm'),
----    ('update', 'Update supplies', 'vwm/supplies','vwm'),
----    ('view', 'View report', 'vwm/report','vwm'),
----    ('create', 'Create report', 'vwm/report','vwm'),
----    ('delete', 'Delete report', 'vwm/report','vwm'),
----    ('update', 'Update report', 'vwm/report','vwm');
--
--
INSERT INTO gemba.policy (policy_id, deleted, policy_code, policy_name, approve, status)
VALUES
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'false', 'ADMIN', 'Admin', 'false', 'ACTIVE');
--    ('1ec241bb-4b79-46a1-be36-d1f58e3551d8', 'false', 'NCC', 'Nhà Cung Cấp', 'false', 'ACTIVE'),
--    ('f1d29db9-94be-4723-aa33-3eaee4158fec', 'false', 'QLKT', 'Kho tổng - P.QLVTTB', 'false', 'ACTIVE'),
--    ('e1696933-066a-4bb1-bbfd-b353dd85edf5', 'false', 'QLPDKT', 'Phê duyệt kho tổng - P.QLVTTB', 'true', 'ACTIVE'),
--    ('37bd420e-f346-40bf-976f-c93d4884608a', 'false', 'QLDA', 'Quản lý dự án', 'false', 'ACTIVE'),
--    ('ddcfa886-1db2-4b10-929d-3c2a6e25e0f0', 'false', 'QLKTC', 'Quản lý khối thi công', 'true', 'ACTIVE'),
--    ('cbe4b286-415f-438e-a428-8b40355f5b6d', 'false', 'QLPDKBCH&TD', 'Phê duyệt ban chỉ huy', 'true', 'ACTIVE'),
--    ('db6b6b47-092f-4a2a-a1cc-a5d32ec0bb57', 'false', 'QLKBCH', 'Thủ kho ban chỉ huy', 'false', 'ACTIVE'),
--    ('f79a3791-4940-4d6c-9b5b-b52617bb4336', 'false', 'QLKTD', 'Tổ đội', 'false', 'ACTIVE');
--
INSERT INTO gemba.pi_policy(pi_id, policy_id)
VALUES
    ('129d211d-d4c9-47d6-b4e9-9251e7b3e129', '3e5881e3-7998-4244-af93-4b69cdc082f0');

INSERT INTO gemba.policy_resource_scope(policy_id, resource_code, tenant_id, scope)
VALUES
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/authority', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/client', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/client', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/group', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/group', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/group', 'iam', 'update'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/pi-policy', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/policy', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/policy', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/policy', 'iam', 'update'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/policy', 'iam', 'delete'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/resource', 'iam', 'update'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/resource', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/resource', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/resource-scope', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/resource-scope', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/resource-scope', 'iam', 'update'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/tenant', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/tenant', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/tenant', 'iam', 'update'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/user', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/user', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/user', 'iam', 'update'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/user', 'iam', 'delete'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/user-group', 'iam', 'create'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/user-group', 'iam', 'view'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/user-group', 'iam', 'update'),
    ('3e5881e3-7998-4244-af93-4b69cdc082f0', 'iam/user-group', 'iam', 'delete');