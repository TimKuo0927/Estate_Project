// Header.stories.tsx
import type { Meta, StoryObj } from '@storybook/react';
import Header from './Header';

const meta: Meta<typeof Header> = {
  title: 'Component/Header',
  component: Header,
  tags: ['autodocs'], // Optional: enables Storybook's auto docs
};

export default meta;
type Story = StoryObj<typeof Header>;

export const Default: Story = {
  render: () => <Header />,
};
