-- Migration script for adding IdNumber and IsThirdPartyEmployee columns to AbpUsers table
-- This script is for PostgreSQL database

-- Add IdNumber column (VARCHAR 18)
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM information_schema.columns 
        WHERE table_name = 'AbpUsers' AND column_name = 'IdNumber'
    ) THEN
        ALTER TABLE "AbpUsers" ADD COLUMN "IdNumber" VARCHAR(18) NULL;
        COMMENT ON COLUMN "AbpUsers"."IdNumber" IS 'User ID Number (Identity Card Number, max 18 characters)';
    END IF;
END $$;

-- Add IsThirdPartyEmployee column (BOOLEAN, default FALSE)
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM information_schema.columns 
        WHERE table_name = 'AbpUsers' AND column_name = 'IsThirdPartyEmployee'
    ) THEN
        ALTER TABLE "AbpUsers" ADD COLUMN "IsThirdPartyEmployee" BOOLEAN NOT NULL DEFAULT FALSE;
        COMMENT ON COLUMN "AbpUsers"."IsThirdPartyEmployee" IS 'Indicates if the user is a third-party employee';
    END IF;
END $$;

-- Create index for IdNumber if it doesn't exist (useful for lookups by ID number)
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM pg_indexes 
        WHERE tablename = 'AbpUsers' AND indexname = 'IX_AbpUsers_IdNumber'
    ) THEN
        CREATE INDEX "IX_AbpUsers_IdNumber" ON "AbpUsers" ("IdNumber");
    END IF;
END $$;

-- Note: Index on IsThirdPartyEmployee is omitted as boolean columns have low cardinality
-- and don't benefit from indexing in most query patterns
