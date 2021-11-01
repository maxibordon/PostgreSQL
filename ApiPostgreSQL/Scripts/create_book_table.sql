-- Table: public.book

-- DROP TABLE public.book;

CREATE TABLE IF NOT EXISTS public.book
(
    title character varying(100) COLLATE pg_catalog."default",
    author character(100) COLLATE pg_catalog."default",
    data json
)

TABLESPACE pg_default;

ALTER TABLE public.book
    OWNER to postgres;